using UnityEngine;

public class towerScript : MonoBehaviour
{
    public string towerName;
    public float towerRange;
    public GameObject[] targets;
    public GameObject target=null;
    void Start()
    {
        InvokeRepeating("FindTarget",0f,0.5f);
    }
    void Update()
    {
        if(target!=null && !target.activeSelf)
        {
            target = null;
        }
    }

    void FindTarget()
    {
        if (target == null) { 
      
            targets = GameObject.FindGameObjectsWithTag("enemy");

            if (targets.Length > 0)
            {
                target = null;
                for (int i = 0; i < targets.Length; i++)
                {
                    float dist = Vector3.Distance(transform.position, targets[i].transform.position);
                    if (dist <= towerRange)
                    {
                        target = targets[i];
                        break;
                    }
                    else
                    {
                        target = null;
                    }
                }
            }
        }
        else //there is a target
        {
            if (!target.activeSelf) { target = null; }
            else//target is active
            { 
                float dist = Vector3.Distance(transform.position, target.transform.position);
                if (dist > towerRange)
                {
                    target = null;
                    FindTarget();
                    //Debug.Log("Enemy out of range. Resetting target");
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,towerRange);
    }
}