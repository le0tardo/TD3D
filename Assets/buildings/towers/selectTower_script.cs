using UnityEngine;
using UnityEngine.EventSystems;

public class selectTower_script : MonoBehaviour
{
    public GameObject selectedTower;
    towerScript twrScr;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !IsPointerOverUI())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.collider.gameObject;

                if (hitObject.CompareTag("towerRayCast"))
                {
                    GameObject clickedTower = hitObject.transform.gameObject;

                    if (selectedTower == clickedTower)
                    {
                        TowerUnselected();
                        selectedTower = null; //already selected
                    }
                    else
                    {
                        TowerUnselected(); //unselect previous
                        selectedTower = clickedTower;
                        twrScr = clickedTower.GetComponent<towerScript>();
                        TowerSelected();
                    }
                }
                else
                {
                    TowerUnselected();
                    selectedTower = null;
                }
            }
        }
    }
    bool IsPointerOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    void TowerUnselected()
    {
        if (twrScr != null)
        {
            twrScr.drawRange = false;
        }
    }
    void TowerSelected()
    {
        if (twrScr != null)
        {
            twrScr.drawRange = true;
        }

    }

}
