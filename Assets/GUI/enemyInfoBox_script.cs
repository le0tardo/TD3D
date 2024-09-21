using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class enemyInfoBox_script : MonoBehaviour
{
    public string enemyInfoName;
    public string enemyInfo_hp;
    public string enemyInfoMaxHp;
    public string enemyInfoSpd;

    public GameObject SelectedEnemy;
    enemy_script SelectedEnemyScript;
    int CurrentHP;

    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text hpText;
    [SerializeField] TMP_Text spdText;
    [SerializeField] Image portraitImg;


    private void Update()
    {
        if (SelectedEnemy != null)
        {
            SelectedEnemyScript=SelectedEnemy.GetComponent<enemy_script>();
            CurrentHP=Mathf.RoundToInt(SelectedEnemyScript.hp);
            portraitImg.sprite = SelectedEnemyScript.portrait;
            nameText.text = enemyInfoName;
            hpText.text = "HP: " + CurrentHP + "/" + enemyInfoMaxHp;
            spdText.text = "SPD: " + enemyInfoSpd;
        }

    }

}
