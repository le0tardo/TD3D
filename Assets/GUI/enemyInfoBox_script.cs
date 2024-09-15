using UnityEngine;

public class enemyInfoBox_script : MonoBehaviour
{
    public GameObject gameMasterObj;
    selectEnemyScript selectScript;
    Animator animator;
    GameObject lastSelectedEnemy=null;
    enemy_script enmScr=null;
    void Start()
    {
        selectScript = gameMasterObj.GetComponent<selectEnemyScript>();
        animator = GetComponent<Animator>();
    }

    private void Update() ////move all this to click function on selectEnemyScript!!!
    {
        if (selectScript.selectedEnemy != null)
        {
            GetEnemyInfo();
            return;
        }


        if (selectScript.selectedEnemy != lastSelectedEnemy)
        { 
            if (selectScript.selectedEnemy != null)
            {
                SlideUp();
            }
            else
            {
                SlideDown();
            }
            lastSelectedEnemy = selectScript.selectedEnemy;
        }
    }

    void GetEnemyInfo()
    {
        enmScr = selectScript.selectedEnemy.GetComponent<enemy_script>();
        Debug.Log("Selected enemy is a " + enmScr.enemyName);
    }
    public void SlideUp()
    {
        animator.Play("slideUp", 0, 0);

    }
    public void SlideDown()
    {
        animator.Play("slideDown", 0, 0);
    }
}
