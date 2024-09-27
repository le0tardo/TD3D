using System.Collections.Generic;
using UnityEngine;

public class gizmoScript : MonoBehaviour
{

    public float buffSpeed;
    public float buffRange;
    public float buffDamage;
    public float buffMagic;
    public float buffBrn;
    public float buffPsn;
    public float buffFrz;

    public bool x_minus=false;
    public bool x_plus=false;
    public bool z_minus=false;
    public bool z_plus=false;

    towerScript twrScr;
    float range;
    public List<GameObject> towers = new List<GameObject>();

    private void Start()
    {
        twrScr = GetComponent<towerScript>();
        range = twrScr.towerRange;

        FindTowers();
    }

    private void OnTriggerEnter(Collider other)
    {
        //if towers.!contains(other.gameobject), add to list
    }

    public void FindTowers()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, range);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("towerRayCast"))
            {
                towerScript twrToAddScr=collider.gameObject.GetComponent<towerScript>();
                if (twrToAddScr.towerType != towerType.Gizmo)
                { 
                 towers.Add(collider.gameObject);
                }
            }
        }
        if (towers.Count > 0)
        {
            ApplyBuff();
        }
    }

    public void ApplyBuff()
    {
        foreach (GameObject tower in towers)
        {
            towerScript towerToBuffScr = tower.GetComponent<towerScript>();

            if (buffSpeed > 0){towerToBuffScr.towerSpeed += buffSpeed;}
            if (buffBrn > 0){towerToBuffScr.tower_brn += buffBrn;Debug.Log("added "+buffBrn+" BRN to "+towerToBuffScr.towerName); }

            if (buffDamage > 0) { if (towerToBuffScr.towerType != towerType.Mage) { towerToBuffScr.towerDamage += buffDamage; }}

        }
    }

    public void ApplyBuffRun()
    {
        //apply buff to towers that are not yet on the list?
        //or just call this, add to list if !contains, and applyBuff to that?
    }

    public void RemoveBuff()
    {
        foreach(GameObject tower in towers)
        {
            if (tower != null)
            { 
            towerScript towerToBuffScr = tower.GetComponent<towerScript>();

            if (buffSpeed > 0) { towerToBuffScr.towerSpeed -= buffSpeed; }
            if (buffBrn > 0) { towerToBuffScr.tower_brn -= buffBrn; Debug.Log("removed " + buffBrn + "BRN from " + towerToBuffScr.towerName); }

            }
        }
    }

    private void OnDestroy()
    {
        if (Application.isPlaying)
        {
            RemoveBuff();
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 3);
    }
}
