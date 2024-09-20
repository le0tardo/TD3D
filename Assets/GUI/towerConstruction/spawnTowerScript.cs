using Unity.VisualScripting;
using UnityEngine;

public class spawnTowerScript : MonoBehaviour
{

    public GameObject towerToSpawn;
    selectBlockScript selectScr;

    private void Start()
    {
        selectScr=GetComponent<selectBlockScript>();
    }

    public void SpawnTower()
    {
        if (selectScr.selectedTowerBlock != null)
        {
            Vector3 spawnPosition = new Vector3(selectScr.selectedTowerBlock.transform.position.x, selectScr.selectedTowerBlock.transform.position.y + 1, selectScr.selectedTowerBlock.transform.position.z);
            Instantiate(towerToSpawn, spawnPosition, Quaternion.identity);
            towerScript twrScr=towerToSpawn.GetComponent<towerScript>();
            playerStats_script.playerGold -= twrScr.towerStatObj.towerCost;
            towerBlock_script blockScr=selectScr.selectedTowerBlock.GetComponent<towerBlock_script>();
            blockScr.Occupy();
            selectScr.selectedTowerBlock = null;
            selectScr.TowerBlockUnselected();
        }
    }
}
