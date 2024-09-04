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
        
    }



    void FindTarget()
    {
        //if (target == null) { 
        
        targets = GameObject.FindGameObjectsWithTag("enemy");
        Debug.Log("Found " + targets.Length + " enemies");

        if (targets.Length > 0) //there is alteast one enemy in the scene
        {
            for (int i = 0; i < targets.Length; i++)
            {
                float dist = Vector3.Distance(transform.position, targets[i].transform.position);
                if (dist <= towerRange)
                {
                    target = targets[i];
                    Debug.Log("Enemy within range!");
                    break;
                }
                else
                {
                    target = null;
                    Debug.Log("Enemy out of range");
                }
            }
        }
        
        //} //why wont target be null??

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,towerRange);
    }
}
