using UnityEngine;
using TMPro;

public class towerInfoBox_script : MonoBehaviour
{
    public GameObject gameMasterObj;
    public GameObject selectedTower;
    public towerScript twrScr;

    public TMP_Text towerName;
    public TMP_Text towerType_txt;
    public TMP_Text towerDamage;
    public TMP_Text towerSpeed;
    public TMP_Text towerRange;
    public TMP_Text towerPSN;
    public TMP_Text towerFRZ;
    public TMP_Text towerBRN;

    string classString="a";

    private void Update()
    {
        //set selected tower from selectTower_script, same var name
        if (selectedTower != null)
        {
            twrScr=selectedTower.GetComponent<towerScript>();

            switch (twrScr.towerType)
            {
                case towerType.Archer:
                    classString = "Marksman";
                break;
                case towerType.Mage:
                    classString = "Mage";
                break;
                case towerType.Gadget:
                    classString = "Artillery";
                break;
                case towerType.Gizmo:
                    classString = "Booster";
                break;
            }
            

            towerName.text = twrScr.towerName;
            towerType_txt.text = "Class: " + classString+ ".\t  LVL: " + twrScr.towerLevel;
            towerDamage.text = "Damage:\t " +twrScr.towerDamage;
            towerSpeed.text = "Speed:\t " +twrScr.publicSpeed;
            towerRange.text = "Range:\t " +twrScr.towerRange;
            towerPSN.text = "PSN:\t" +twrScr.tower_psn;
            towerFRZ.text = "FRZ:\t" +twrScr.tower_frz;
            towerBRN.text = "BRN:\t" +twrScr.tower_brn;
        }
    }

    public void UpgradeTower()
    {
        if (selectedTower != null)
        {
            GameObject upgTower= Instantiate(twrScr.towerStatObj.upgradeTowerObj,selectedTower.transform.position,Quaternion.identity);
            towerScript upgTwrScr=upgTower.GetComponent<towerScript>();
            towerScript currTwrScr = selectedTower.GetComponent<towerScript>();
            upgTwrScr.groundBlock = currTwrScr.groundBlock;
            //Debug.Log(upgTwrScr.groundBlock.name);

            Destroy(selectedTower);

            selectTower_script selTwrScr=gameMasterObj.GetComponent<selectTower_script>();
            selTwrScr.selectedTower = null;
            selTwrScr.TowerUnselected();
            selectedTower = null;
        }
    }
    public void SellTower()
    {
        if (selectedTower != null)
        {
            Debug.Log("this never happens?!");
            playerStats_script.playerGold += Mathf.RoundToInt(twrScr.towerStatObj.towerCost/2);
            Destroy(selectedTower);
            selectTower_script selTwrScr = gameMasterObj.GetComponent<selectTower_script>();
            selTwrScr.selectedTower = null;
            selTwrScr.TowerUnselected();
            selectedTower = null;
        }
    }
}
