using UnityEngine;
using TMPro;

public class towerSpawnButton_script : MonoBehaviour
{
    public towerScriptableObjectScript tower;
    public GameObject towerToSpawn;
    public GameObject gameMasterObj;
    spawnTowerScript spawnScr;
    public TMPro.TextMeshProUGUI cost;
    public GameObject cantBuyBox;

    private Color defaultColor;

    private void Start()
    {
        cost.text = tower.towerCost.ToString();
        spawnScr=gameMasterObj.GetComponent<spawnTowerScript>();

        defaultColor = cost.color;
    }

    private void Update()
    {
        cantBuyBox.SetActive(CanBuy());

        if (CanBuy())
        {
            cost.color = Color.red;
        }
        else
        {
            cost.color = defaultColor;
        }
    }

    public void ClickedMe()
    {
        if (!CanBuy()){ 
            spawnScr.towerToSpawn = towerToSpawn;
            spawnScr.SpawnTower();
        }
    }

    bool CanBuy()
    {
        if (playerStats_script.playerGold < tower.towerCost)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
