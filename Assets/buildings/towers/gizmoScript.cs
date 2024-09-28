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
    }

    public void AddToList(GameObject towerToAdd)
    {
        towers.Add(towerToAdd);
        ApplyBuff(towerToAdd);
    }

    void ApplyBuff(GameObject towerToBuff)
    {
        towerScript towerToBuffScr = towerToBuff.GetComponent<towerScript>();
        if (buffSpeed > 0) { towerToBuffScr.towerSpeed += buffSpeed;}
    }

    public void RemoveBuff()
    {
        foreach(GameObject tower in towers)
        {
            if (tower != null)
            { 
                towerScript towerToBuffScr = tower.GetComponent<towerScript>();

                if (buffSpeed > 0) { towerToBuffScr.towerSpeed -= buffSpeed; }

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
        //Gizmos.color = Color.green;
        //Gizmos.DrawWireSphere(transform.position, 3);
    }
}
