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

    //public float buffBrnAOE;
    //public float buffFrzAOE;
    //fire buff!furnace, if type==mage&&brn>0, do buff, else if type==archer{just do buff, else if type==artillery, dont do buff, buffString="";

    towerScript twrScr;
    float range;
    public List<GameObject> towers = new List<GameObject>();

    public GameObject buffFX;
    string buffString;
    float buffAmmount;

    public bool buffAOE;

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

        towerScript towerToBuffScr = towerToBuff.GetComponent<towerScript>();
        if (buffSpeed > 0) {
            if (!buffAOE)
            {
                if (towerToBuffScr.towerType == towerType.Archer || towerToBuffScr.towerType == towerType.Mage)
                {
                    towerToBuffScr.towerSpeed += buffSpeed; buffString = "SPD"; buffAmmount = buffSpeed;
                }
                else
                {
                    buffString = "";
                }
            }
            else
            {
                if (towerToBuffScr.towerType == towerType.Gadget)
                {
                    towerToBuffScr.towerSpeed += buffSpeed; buffString = "SPD"; buffAmmount = buffSpeed;
                }
                else
                {
                    buffString = "";
                }
            }
            //towerToBuffScr.towerSpeed += buffSpeed; buffString = "SPD";buffAmmount = buffSpeed;
        
        } 
        if (buffRange > 0) { towerToBuffScr.towerRange += buffRange; buffString = "RNG";buffAmmount = buffRange; }
        if (buffPsn > 0) { towerToBuffScr.tower_psn += buffPsn;buffString = "PSN";buffAmmount = buffPsn;}
        
        if (buffBrn > 0) //burn buff skips mage and frost mage. 
        {
            if (towerToBuffScr.towerType == towerType.Archer || towerToBuffScr.towerType == towerType.Gadget) {
                towerToBuffScr.tower_brn += buffBrn; buffString = "BRN"; buffAmmount = buffBrn; towerToBuffScr.tower_frz -= buffBrn;
            }else if (towerToBuffScr.towerType == towerType.Mage)
            {
                if (towerToBuffScr.tower_brn > 0)
                {
                    towerToBuffScr.tower_brn += buffBrn; towerToBuffScr.tower_frz -= buffBrn; buffString = "BRN"; buffAmmount = buffBrn;
                }
                else
                {
                    buffString = "";
                }
            }
        }
        
        if (buffDamage > 0) //only physical damage
        { 
            if(towerToBuffScr.towerType == towerType.Mage)
            {
                buffString = ""; //to stop buffFX from instantiating
            }
            else
            {
                towerToBuffScr.towerDamage += buffDamage; buffString = "DMG"; buffAmmount = buffDamage;
            }
        }
        if (buffMagic > 0)
        {
            if (towerToBuffScr.towerType == towerType.Mage)
            {
                towerToBuffScr.towerDamage += buffMagic;buffString = "DMG";buffAmmount = buffMagic;
            }
            else
            {
                buffString = "";//to stop buffFX from instantiating
            }
        }

        if (buffFrz > 0)
        {
            if (towerToBuffScr.towerType == towerType.Gadget)
            {
                towerToBuffScr.tower_frz += buffFrz; buffString = "FRZ"; buffAmmount = buffFrz;towerToBuffScr.tower_brn -= buffFrz;
            }
            else if (towerToBuffScr.towerType == towerType.Mage && towerToBuffScr.tower_frz > 0) //only on frost mages
            {
                towerToBuffScr.tower_frz += buffFrz; buffString = "FRZ"; buffAmmount = buffFrz;
            }
            else
            {
                buffString = "";
            }
        }

        if (buffFX != null && buffString != "")
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

                if (buffDamage > 0)
                {
                    if (towerToBuffScr.towerType == towerType.Mage)
                    {
                        //do notthing
                    }
                    else
                    { 
                        towerToBuffScr.towerDamage -= buffDamage;
                    }
                }
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
