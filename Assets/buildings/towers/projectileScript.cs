using UnityEngine;

public class projectileScript : MonoBehaviour
{
    GameObject targetObj;
    Vector3 targetPosition;
    Vector3 startPosition;
    public GameObject shooter;
    shooterScript shooterScr;
    towerScript towerScr;

    public int dmg;
    public float spd; //not attack speed!

    public bool magic=false;

    public int psn=0;
    public int frz=0;
    public int brn= 0;

    float progress;
    public GameObject hitFX;

    void Awake()
    {
        shooterScr = shooter.GetComponent<shooterScript>();
        towerScr = shooter.GetComponentInParent<towerScript>();
        dmg = Mathf.RoundToInt(towerScr.towerDamage);

        startPosition = transform.position;
        this.gameObject.SetActive(false);
        targetPosition= new Vector3(0, 0, 0);
    }

    private void OnEnable()
    {
        dmg = Mathf.RoundToInt(towerScr.towerDamage);
        transform.localPosition = startPosition;
        progress = 0;
        transform.rotation = shooter.transform.rotation;

        if (shooterScr.target != null)
        {
            targetObj = shooterScr.target;
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
    private void OnDisable()
    {
        transform.position = startPosition;
    }

    void Update()
    {
        if (targetObj == null || !targetObj.activeSelf)
        {
            //get backup vecotr posiiotn if enemy dies before impact. Move to that instead.
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, spd * Time.deltaTime);
            Vector3 movementDirection = (transform.position - startPosition).normalized;
            if (movementDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(movementDirection);
                transform.rotation = targetRotation;
            }
            float dist = Vector3.Distance(transform.position, targetPosition);
            if (dist < 0.1f)
            {
                this.gameObject.SetActive(false);
            }
        }
        else //target exists and is active
        {
            if (isActiveAndEnabled)
            {
                //get backup transform id enemy dies before projectile hits
                targetPosition = targetObj.transform.position;

                //move straight towards
                //transform.position = Vector3.MoveTowards(transform.position, targetObj.transform.position, spd * Time.deltaTime); .

                //move towards in an arc
                if (progress < 1f)
                {
                    float arcHeight = 1.5f;

                    progress += Time.deltaTime * spd / Vector3.Distance(startPosition, targetObj.transform.position);
                    Vector3 lerpPosition = Vector3.Lerp(startPosition, targetObj.transform.position, progress);
                    Vector3 upwardsDirection = Vector3.up * Mathf.Sin(Mathf.PI * progress) * arcHeight;
                    transform.position = lerpPosition + upwardsDirection;

                    Vector3 movementDirection = (transform.position - startPosition).normalized;
                    if (movementDirection != Vector3.zero)
                    {
                        Quaternion targetRotation = Quaternion.LookRotation(movementDirection);
                        transform.rotation = targetRotation;
                    }
                }

                float dist = Vector3.Distance(transform.position, targetObj.transform.position);
                if (dist < 0.1f)
                {
                    enemy_script targetScr = targetObj.GetComponent<enemy_script>();

                    if (magic)
                    {
                        targetScr.TakeMagicDamage(dmg);
                    }
                    else
                    {
                        targetScr.TakeDamage(dmg);
                    }


                    //targetScr.freeze or burn or whtever
                    if (hitFX != null)
                    {
                        hitFX_script hitScr = hitFX.GetComponent<hitFX_script>();
                        hitScr.Hit(transform.position);
                    }

                    this.gameObject.SetActive(false);
                }
            }
        }
    }
}
