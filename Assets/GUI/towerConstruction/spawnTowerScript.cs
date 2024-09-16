using Unity.VisualScripting;
using UnityEngine;

public class spawnTowerScript : MonoBehaviour
{


    public GameObject ArcherTower;
    public GameObject MageTower;

    selectBlockScript selectScr;

    private void Start()
    {
        selectScr=GetComponent<selectBlockScript>();
    }

    public void BuildArcherTower()
    {
        if (selectScr.selectedTowerBlock != null)
        {
            Vector3 spawnPosition = new Vector3(selectScr.selectedTowerBlock.transform.position.x, selectScr.selectedTowerBlock.transform.position.y+1, selectScr.selectedTowerBlock.transform.position.z);
            Instantiate(ArcherTower, spawnPosition, Quaternion.identity);
            selectScr.selectedTowerBlock = null;
            selectScr.TowerBlockUnselected();
        }
    }
    public void BuildMageTower()
    {
        if (selectScr.selectedTowerBlock != null)
        {
            Vector3 spawnPosition = new Vector3(selectScr.selectedTowerBlock.transform.position.x, selectScr.selectedTowerBlock.transform.position.y + 1, selectScr.selectedTowerBlock.transform.position.z);
            Instantiate(MageTower, spawnPosition, Quaternion.identity);
            selectScr.selectedTowerBlock = null;
            selectScr.TowerBlockUnselected();
        }
    }
}
