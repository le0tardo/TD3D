using UnityEngine;

public class selectEnemyScript : MonoBehaviour
{
    public GameObject selectedEnemy;
    private GameObject lastSelectedEnemy=null;
    public GameObject enemyMarker;
    public GameObject enemyInfoBox;
    enemyInfoBox_script infoBoxScr;

    private void Start()
    {
        infoBoxScr = enemyInfoBox.GetComponent<enemyInfoBox_script>();
        enemyInfoBox.SetActive(false);
    }
    private void Update()
    {
        if (selectedEnemy != null)
        {
            enemyMarker.transform.position = new Vector3(selectedEnemy.transform.position.x, selectedEnemy.transform.position.y + 0.1f, selectedEnemy.transform.position.z);
        }
        else
        {
            if (enemyMarker.transform.position != Vector3.zero)
            {
                infoBoxScr.SlideDown();
                enemyMarker.transform.position = Vector3.zero;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.collider.gameObject;

                if (hit.collider.gameObject.CompareTag("enemyRayCast"))
                {
                    enemyInfoBox.SetActive(true);

                    if (hitObject != lastSelectedEnemy) { 
                        selectedEnemy = hitObject.transform.parent.gameObject;
                        infoBoxScr.SlideUp();
                        GetEnemyInfo(selectedEnemy);
                        lastSelectedEnemy = hitObject;
                    }
                    else
                    {
                        infoBoxScr.SlideDown();
                        selectedEnemy = null;
                        lastSelectedEnemy=null;
                    }
                }
                else
                {
                    if (lastSelectedEnemy!=null && lastSelectedEnemy.CompareTag("enemyRayCast"))
                    {
                        infoBoxScr.SlideDown();
                    }

                    selectedEnemy = null;
                    lastSelectedEnemy = null;
                }
            }
        }
    }

    void GetEnemyInfo(GameObject clickedObj)
    {
        infoBoxScr.SelectedEnemy = clickedObj;

        enemy_script enmScr=clickedObj.GetComponent<enemy_script>();
        enemyMovement_script enmMov=clickedObj.GetComponent<enemyMovement_script>();

        infoBoxScr.enemyInfoName = enmScr.enemyName;
        infoBoxScr.enemyInfoMaxHp = enmScr.maxHp.ToString();
        infoBoxScr.enemyInfoSpd=enmMov.spd.ToString();

    }

    void SendEnemyInfo()
    {

    }
}
