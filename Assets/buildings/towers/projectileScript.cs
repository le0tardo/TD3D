using UnityEngine;

public class projectileScript : MonoBehaviour
{
    GameObject targetObj;
    Vector3 targetPosition;
    Vector3 startPosition;
    Vector3 startWorldPosition;
    Vector3 startLocalPosition;
    public GameObject shooter;
    shooterScript shooterScr;
    towerScript towerScr;

    public int dmg;
    public float spd; //not attack speed!

    public bool magic=false;
    public bool aoe = false;

    public int psn=0;
    public int frz=0;
    public int brn= 0;

    float progress;
    public GameObject hitFX;
    public GameObject aoeFX;
    public GameObject psnFX;

    void Awake()
    {
        shooterScr = shooter.GetComponent<shooterScript>();
        towerScr = shooter.GetComponentInParent<towerScript>();
        dmg = Mathf.RoundToInt(towerScr.towerDamage);



        startPosition = transform.position;
        startWorldPosition=transform.position;
        startLocalPosition=transform.localPosition;

        this.gameObject.SetActive(false);
        targetPosition= new Vector3(0, 0, 0);
    }

    private void OnEnable()
    {
        startPosition = transform.parent.TransformPoint(startLocalPosition);
        transform.position = startPosition;
        dmg = Mathf.RoundToInt(towerScr.towerDamage);
        psn = Mathf.RoundToInt(towerScr.tower_psn);
        frz = Mathf.RoundToInt(towerScr.tower_frz);
        brn = Mathf.RoundToInt(towerScr.tower_brn);

        if (psnFX != null) 
        { 
            if (psn > 0) { psnFX.SetActive(true); }
            else { psnFX.SetActive(false); }
        }

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
        //transform.position = startPosition;
        transform.localPosition= startLocalPosition;
    }

    void Update()
    {
        if (targetObj != null)
        {
            targetPosition = targetObj.transform.position;
        }

        if (progress < 1f) //move towards targetPosition in an arc
        {
            float arcHeight = 1.5f;
            progress += Time.deltaTime * spd / Vector3.Distance(startPosition, targetPosition);
            Vector3 lerpPosition = Vector3.Lerp(startPosition, targetPosition, progress);
            Vector3 upwardsDirection = Vector3.up * Mathf.Sin(Mathf.PI * progress) * arcHeight;
            transform.position = lerpPosition + upwardsDirection;
            Vector3 movementDirection = (transform.position - startPosition).normalized;

            if (movementDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(movementDirection);
                transform.rotation = targetRotation;
            }
        }

        float dist = Vector3.Distance(transform.position, targetPosition);
        if (dist < 0.1f)
        {

            if (!aoe)
            {
                if (targetObj != null)
                {
                    enemy_script targetObjScr = targetObj.GetComponent<enemy_script>();
                    if (magic) { targetObjScr.TakeMagicDamage(dmg);}
                    else { targetObjScr.TakeDamage(dmg); }
                    targetObjScr.StatusChange(psn,frz,brn);
                    if (hitFX != null)
                    {
                        hitFX_script hitScr = hitFX.GetComponent<hitFX_script>();
                        hitScr.Hit(transform.position);
                    }
                    this.gameObject.SetActive(false);
                }
                else
                {
                    this.gameObject.SetActive(false);
                }
            }
            else
            {
                if (aoeFX != null)
                {
                    aoeFX.transform.position = targetPosition;
                    aoeFX.SetActive(true);
                    this.gameObject.SetActive(false);
                }
            }
        }
    }
}
