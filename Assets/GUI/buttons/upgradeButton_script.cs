using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class upgradeButton_script : MonoBehaviour
{
    public TMP_Text upgCost;
    public GameObject towerInfoBox;
    public GameObject cantBuyBox;
    public GameObject costBox;
    towerInfoBox_script twrInfoScr;
    towerScript twrScr;

    Button button;

    void Start()
    {
        twrInfoScr=towerInfoBox.GetComponent<towerInfoBox_script>();
        button=GetComponent<Button>();
    }

    void Update()
    {
        if (twrScr != null)
        {
            if (twrScr.towerStatObj.upgradeTowerObj != null)
            {
                button.interactable = true;
                costBox.SetActive(true);
            }
            else
            {
                button.interactable = false;
                costBox.SetActive(false);
            }
        }

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
            if (playerStats_script.playerGold < twrScr.towerStatObj.upgradeCost||twrScr.towerStatObj.upgradeTowerObj==null)
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
