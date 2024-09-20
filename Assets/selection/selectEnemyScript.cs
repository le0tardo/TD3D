using UnityEngine;

public class selectEnemyScript : MonoBehaviour
{
    public GameObject selectedEnemy;
    private GameObject lastSelectedEnemy=null;
    public GameObject enemyMarker;
    public GameObject enemyInfoBox;
    enemyInfoBox_script infoBoxScr;
    Animator boxAnimator;
    bool boxUp = false;

    private void Start()
    {
        infoBoxScr = enemyInfoBox.GetComponent<enemyInfoBox_script>();
        boxAnimator = enemyInfoBox.GetComponent<Animator>();
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

                    if (hitObject != lastSelectedEnemy) { 
                        selectedEnemy = hitObject.transform.parent.gameObject;
                        EnemySelected();
                        GetEnemyInfo(selectedEnemy);
                        lastSelectedEnemy = hitObject;
                    }
                    else
                    {
                        EnemyUnselected();
                        selectedEnemy = null;
                        lastSelectedEnemy=null;
                    }
                }
                else
                {
                    if (lastSelectedEnemy!=null && lastSelectedEnemy.CompareTag("enemyRayCast"))
                    {
                        EnemyUnselected();
                    }

                    selectedEnemy = null;
                    lastSelectedEnemy = null;
                }
            }
        }
        if (selectedEnemy == null&&boxUp)
        {
            EnemyUnselected();
            return;
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

    void EnemySelected()
    {
        if (!boxUp)
        {
            boxAnimator.Play("slideUp", 0, 0);
            boxUp = true;
        }
    }
    void EnemyUnselected()
    {
        if (boxUp)
        {
            boxAnimator.Play("slideDown",0,0);
            boxUp = false;
        }
    }
}
