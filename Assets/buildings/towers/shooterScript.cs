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
        InvokeRepeating("Fire", 0f, coolDown);
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

            //InvokeRepeating("Fire", 0f, coolDown);
        }
        else
        {
            //return to originalDirection?
        }

 
    }

    void Fire()
    {
        if (target != null)
        {
            if (!projectile.activeSelf) 
            {
                Debug.Log("FIRE!!!");
                projectile.SetActive(true); //projectile[i] set active!
            }
        }
    }

}
