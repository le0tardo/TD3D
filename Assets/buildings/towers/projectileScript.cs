using UnityEngine;

public class projectileScript : MonoBehaviour
{
    GameObject targetObj;
    Vector3 startPosition;
    public GameObject shooter;
    shooterScript shooterScr;
    public float spd=5;

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
        transform.rotation = Quaternion.Euler(0, 0, 0);
        //Debug.Log("X: " + shooter.transform.rotation.x + ". Y:" + shooter.transform.rotation.y + ". Z:" + shooter.transform.rotation.z+".");
        Debug.Log("Current Projectile Rotation: " + transform.rotation.eulerAngles);
        Debug.Log("Current Shooter Rotation: " + shooter.transform.rotation.eulerAngles);

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

        if (targetObj == null)
        {
            this.gameObject.SetActive(false);
        }

        if (isActiveAndEnabled)
        {
            //transform.position = Vector3.MoveTowards(transform.position, targetObj.transform.position, spd * Time.deltaTime); //move straight towards.

            if (progress < 1f) //move towards in an arc
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
                    //transform.rotation= targetRotation;
                }
            }

            
            float dist = Vector3.Distance(transform.position, targetObj.transform.position);
            if (dist < 0.5f)
            {
                this.gameObject.SetActive(false);
            }
        }
    }

}
