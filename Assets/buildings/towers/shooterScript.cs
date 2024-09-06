using Unity.VisualScripting;
using UnityEngine;

public class shooterScript : MonoBehaviour
{
    public GameObject target = null;
    public GameObject projectile;
    towerScript twrScr;
    public float coolDown=1.0f;

    private void Start()
    {
        twrScr=GetComponentInParent<towerScript>();

        float randomDelay = Random.value;
        InvokeRepeating("Fire", randomDelay, coolDown);
    }

    private void Update()
    {
        if (twrScr.target != null)
        {
            target = twrScr.target;
        }
        else
        {
            target = null;
        }

        if (target != null)
        {
            //rotate towards target
            Vector3 dir=target.transform.position-transform.position;
            Quaternion qRot = Quaternion.LookRotation(dir);
            Vector3 rot = qRot.eulerAngles;
            transform.rotation = Quaternion.Euler(0f,rot.y,0f);
        }
        else
        {
            //return to originalDirection? nah, looks fine
        }
    }

    void Fire()
    {
        if (target != null && target.activeSelf)
        {
            if (!projectile.activeSelf) 
            {
                Debug.Log("FIRE!!!");
                projectile.SetActive(true); //projectile[i] set active!
            }
        }
    }

}
