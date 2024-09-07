using UnityEngine;

public class projectileScript : MonoBehaviour
{
    GameObject targetObj;
    Vector3 targetPosition;
    Vector3 startPosition;
    public GameObject shooter;
    shooterScript shooterScr;

    public float minDmg=1;
    public float maxDmg=1;
    float dmg;
    public float spd;

    public bool psn=false;
    public bool frz=false;
    public bool brn= false;

    float progress;

    void Awake()
    {
        shooterScr = shooter.GetComponent<shooterScript>();
        startPosition = transform.position;
        this.gameObject.SetActive(false);
        targetPosition= new Vector3(0, 0, 0);
    }

    private void OnEnable()
    {
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
                    dmg =Random.Range(minDmg,maxDmg);
                    enemy_script targetScr = targetObj.GetComponent<enemy_script>();
                    targetScr.TakeDamage(dmg);

                    //targetScr.freeze or burn or whtever

                    this.gameObject.SetActive(false);
                }
            }
        }
    }
}
