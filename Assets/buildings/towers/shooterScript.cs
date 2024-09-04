using UnityEngine;

public class shooterScript : MonoBehaviour
{
    GameObject target = null;
    towerScript twrScr;
    public float coolDown=1;

    private void Start()
    {
        twrScr=GetComponentInParent<towerScript>();
        if (twrScr != null )
        {
            Debug.Log("Found my tower!");
        }
        else
        {
            Debug.Log("no tower...");
        }
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

            InvokeRepeating("Fire", 0f, coolDown);
        }
        else
        {
            //return to originalDirection?
        }

 
    }

    void Fire()
    {
        Debug.Log("FIRE!!!");
    }

}
