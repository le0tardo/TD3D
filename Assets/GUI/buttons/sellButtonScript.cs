using UnityEngine;
using TMPro;

public class sellButtonScript : MonoBehaviour
{
    public GameObject gameMasterObj;
    public GameObject coinFX;
    selectTower_script twrSlctScr;
    GameObject selectedTower;
    towerScript twrScr;
    public TMP_Text sellCost;
    int goldPrice;
    void Start()
    {
        twrSlctScr=gameMasterObj.GetComponent<selectTower_script>();
    }

    void Update()
    {
        selectedTower = twrSlctScr.selectedTower;
        if (selectedTower != null)
        {
            twrScr=selectedTower.GetComponent<towerScript>();
            goldPrice=Mathf.RoundToInt(twrScr.towerStatObj.towerCost/3);
            sellCost.text = "+"+goldPrice;
        }  
    }

    public void SellTower()
    {
        if (selectedTower != null&&twrScr!=null)
        {
            playerStats_script.playerGold += goldPrice;
            twrScr.ClearTowerBlock();

            coinFX.transform.position=selectedTower.transform.position;
            coinFX.SetActive(true);

            Destroy(selectedTower);
            selectedTower=null;
            twrSlctScr.selectedTower = null;
            twrSlctScr.TowerUnselected();


        }
    }
}
