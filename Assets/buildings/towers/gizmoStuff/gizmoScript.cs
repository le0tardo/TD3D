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

    towerScript twrScr;
    float range;
    public List<GameObject> towers = new List<GameObject>();

    public GameObject buffFX;
    string buffString;
    float buffAmmount;

    private void Start()
    {
        twrScr = GetComponent<towerScript>();

        buffString = "BUFF";
        buffAmmount = 1;
    }

    public void AddToList(GameObject towerToAdd)
    {
        towers.Add(towerToAdd);
        ApplyBuff(towerToAdd);
    }

    void ApplyBuff(GameObject towerToBuff)
    {
        //if tower to buff .towerType== allowedTowerType

        towerScript towerToBuffScr = towerToBuff.GetComponent<towerScript>();
        if (buffSpeed > 0) { towerToBuffScr.towerSpeed += buffSpeed; buffString = "SPD";buffAmmount = buffSpeed;}
        if (buffRange > 0) { towerToBuffScr.towerRange += buffRange; buffString = "RNG";buffAmmount = buffRange; }
        if (buffPsn > 0) { towerToBuffScr.tower_psn += buffPsn;buffString = "PSN";buffAmmount = buffPsn;}
        if (buffBrn > 0) { towerToBuffScr.tower_brn += buffBrn;towerToBuffScr.tower_frz -= buffBrn;buffString = "BRN";buffAmmount = buffBrn;}
        //frost ++; brn--;
        
        if (buffFX != null)
        {
            Vector3 spawnPos=new Vector3(towerToBuff.transform.position.x,towerToBuff.transform.position.y+2,towerToBuff.transform.position.z);
            GameObject BuffTextObj = Instantiate(buffFX, spawnPos, Quaternion.identity);
            BuffFX buffFXscr=BuffTextObj.GetComponent<BuffFX>();
            buffFXscr.buffText.text = "+"+buffAmmount+" "+buffString;
            towerToBuffScr.PlayWobble();
        }



    }

    public void RemoveBuff()
    {
        foreach(GameObject tower in towers)
        {
            if (tower != null)
            { 
                towerScript towerToBuffScr = tower.GetComponent<towerScript>();

                if (buffSpeed > 0) { towerToBuffScr.towerSpeed -= buffSpeed; }
                if (buffRange > 0) { towerToBuffScr.towerRange -= buffRange; }
                if (buffPsn > 0) { towerToBuffScr.tower_psn -= buffPsn; }
                if (buffBrn > 0) { towerToBuffScr.tower_brn -= buffBrn; towerToBuffScr.tower_frz += buffBrn;}
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
}
