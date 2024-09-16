using UnityEngine;
using UnityEngine.EventSystems;

public class selectBlockScript : MonoBehaviour
{
    public GameObject selectedTowerBlock;
    public GameObject towerBlockMarker;
    public GameObject towerBuildBox;

    Animator boxAnimator;
    bool boxUp=false;
    void Start()
    {
        boxAnimator=towerBuildBox.GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&&!IsPointerOverUI())
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
                        TowerBlockUnselected();
                    }
                    else
                    {
                        selectedTowerBlock = clickedTowerBlock;
                        TowerBlockSelected();
                    }
                }
                else
                {
                    selectedTowerBlock = null;
                    TowerBlockUnselected();
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

    bool IsPointerOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    void TowerBlockSelected()
    {
        if (!boxUp) 
        { 
            boxAnimator.Play("slideUp",0,0);
            boxUp = true;
        }
    }
    public void TowerBlockUnselected()
    {
        if (boxUp)
        { 
            boxAnimator.Play("slideDown", 0, 0);
            boxUp = false;
        }
    }
}
