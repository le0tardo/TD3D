using UnityEngine;

public class selectBlockScript : MonoBehaviour
{
    public GameObject selectedTowerBlock;
    public GameObject towerBlockMarker;
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.collider.gameObject;

                if (hitObject.CompareTag("towerBlock"))
                {
                    GameObject clickedTowerBlock = hitObject.transform.parent.gameObject;

                    if (selectedTowerBlock == clickedTowerBlock)
                    {
                        selectedTowerBlock = null; //already selected
                    }
                    else
                    {
                        selectedTowerBlock = clickedTowerBlock;
                    }
                }
                else
                {
                    selectedTowerBlock = null;
                }
            }
        }


        if (selectedTowerBlock != null)
        {
            towerBlockMarker.transform.position = new Vector3(selectedTowerBlock.transform.position.x, selectedTowerBlock.transform.position.y+1.1f, selectedTowerBlock.transform.position.z);//selectedTowerBlock.transform.position;
        }
        else
        {
            towerBlockMarker.transform.position=Vector3.zero;
        }
    }
}
