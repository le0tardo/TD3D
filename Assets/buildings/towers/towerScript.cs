using UnityEngine;


public class towerScript : MonoBehaviour
{
    public towerScriptableObjectScript towerStatObj;

    public string towerName;
    public towerType towerType;
    public int towerLevel;
    public string towerDesc;

    public float towerRange;
    public float towerDamage;
    public float towerSpeed;

    public float tower_psn;
    public float tower_frz;
    public float tower_brn;

    public GameObject rangeMarker;
    public bool drawRange = false;

    public GameObject[] targets;
    public GameObject target=null;

    public GameObject groundBlock;
    void Awake()
    {
        InvokeRepeating("FindTarget",0f,0.5f);
        SetStats();
    }
    void Update()
    {
        if(target!=null && !target.activeSelf)
        {
            target = null;
        }

        if (drawRange)
        {
            rangeMarker.SetActive(true);
        }
        else
        {
            rangeMarker.SetActive(false);
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

    void SetStats()
    {
        towerName = towerStatObj.towerName;
        towerType = towerStatObj.towerType;
        towerLevel = towerStatObj.towerLevel;
        towerDesc = towerStatObj.towerDescription;
        towerRange = towerStatObj.towerRange;
        towerDamage = towerStatObj.towerDamage;
        towerSpeed = towerStatObj.towerSpeed;

        tower_frz = towerStatObj.frz;
        tower_psn = towerStatObj.psn;
        tower_brn = towerStatObj.brn;

        rangeMarker.transform.localScale = new Vector3(towerRange, towerRange, 1f);
    }

    public void ClearTowerBlock()
    {
        if (groundBlock != null)
        {
            towerBlock_script twrBlockScr=groundBlock.GetComponent<towerBlock_script>();
            twrBlockScr.Clear();
        }
    }
}
