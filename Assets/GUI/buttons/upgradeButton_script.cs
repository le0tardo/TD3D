using UnityEngine;
using TMPro;
public class upgradeButton_script : MonoBehaviour
{
    public TMP_Text upgCost;
    public GameObject towerInfoBox;
    public GameObject cantBuyBox;
    towerInfoBox_script twrInfoScr;
    towerScript twrScr;

    void Start()
    {
        twrInfoScr=towerInfoBox.GetComponent<towerInfoBox_script>();
    }

    void Update()
    {
        cantBuyBox.SetActive(CantBuy());

        if (twrInfoScr != null)
        {
            twrScr = twrInfoScr.twrScr;
            if (twrScr != null) { upgCost.text = twrScr.towerStatObj.upgradeCost.ToString(); }
        }

        if (CantBuy())
        {
            upgCost.color = Color.red;
        }
        else
        {
            upgCost.color = Color.white;
        }
    }

    public void TryToUpgrade()
    {
        if (!CantBuy())
        {
            twrInfoScr.UpgradeTower();
            playerStats_script.playerGold -= twrScr.towerStatObj.upgradeCost;
        }
    }

    bool CantBuy()
    {
        if (twrScr != null)
        { 
            if (playerStats_script.playerGold < twrScr.towerStatObj.upgradeCost)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}
