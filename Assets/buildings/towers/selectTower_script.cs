using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using static Unity.VisualScripting.Member;

public class selectTower_script : MonoBehaviour
{
    public GameObject selectedTower;
    public GameObject towerInfoBox;
    towerInfoBox_script twrInfoScr;
    Animator boxAnimator;
    towerScript twrScr;
    AudioSource source;

    bool boxUp = false;
    void Start()
    {
        boxAnimator = towerInfoBox.GetComponent<Animator>();
        twrInfoScr=towerInfoBox.GetComponent<towerInfoBox_script>();
        source=GetComponent<AudioSource>();
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
                        twrInfoScr = towerInfoBox.GetComponent<towerInfoBox_script>();
                        twrInfoScr.selectedTower = selectedTower;
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

    public void TowerUnselected()
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
        }
        if (!boxUp)
        {
            boxAnimator.Play("slideUp", 0, 0);
            boxUp = true;
        }

        source.pitch = Random.Range(0.75f, 1.25f);
        source.Play();
    }

}
