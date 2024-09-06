using UnityEngine;

public class projectileScript : MonoBehaviour
{
    GameObject targetObj;
    Vector3 startPosition;
    public GameObject shooter;
    shooterScript shooterScr;
    public float dmg;
    public float spd;

    float progress;

    void Awake()
    {
        shooterScr = shooter.GetComponent<shooterScript>();
        startPosition = transform.position;
        this.gameObject.SetActive(false);
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
            this.gameObject.SetActive(false);
        }

        if (isActiveAndEnabled)
        {
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
                    transform.rotation= targetRotation;
                }
            }

            float dist = Vector3.Distance(transform.position, targetObj.transform.position);
            if (dist < 0.25f)
            {
                enemy_script targetScr= targetObj.GetComponent<enemy_script>();
                targetScr.TakeDamage(dmg);
                this.gameObject.SetActive(false);
            }
        }
    }

}
