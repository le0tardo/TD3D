using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class selectTower_script : MonoBehaviour
{
    public GameObject selectedTower;
    public GameObject towerInfoBox;
    Animator boxAnimator;
    towerScript twrScr;

    bool boxUp = false;
    void Start()
    {
        boxAnimator = towerInfoBox.GetComponent<Animator>();
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
        if (boxUp)
        {
            boxAnimator.Play("slideDown", 0, 0);
            boxUp = false;
        }

    }
    void TowerSelected()
    {
        if (twrScr != null)
        {
            twrScr.drawRange = true;
            Debug.Log("Selected tower is "+twrScr.towerStatObj.towerName);
        }
        if (!boxUp)
        {
            boxAnimator.Play("slideUp", 0, 0);
            boxUp = true;
        }
    }

}
