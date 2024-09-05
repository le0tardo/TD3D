using UnityEngine;

public class projectileScript : MonoBehaviour
{
    Transform target;
    shooterScript shooterScr;
    public float spd=10;
    void Awake()
    {
        shooterScr = GetComponentInParent<shooterScript>();
        this.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        if (shooterScr.target != null)
        {
            target = shooterScr.target.transform;
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, spd * Time.deltaTime);
        float dist = Vector3.Distance(transform.position, target.position);
        //Debug.Log(dist);

        if (dist < 0.5f)
        {
            this.gameObject.SetActive(false);
            //Destroy(this.gameObject);
        }
    }
}
