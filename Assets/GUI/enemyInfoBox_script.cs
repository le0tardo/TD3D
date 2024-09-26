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
    [SerializeField] TMP_Text dmgText;
    [SerializeField] TMP_Text armorText;
    [SerializeField] TMP_Text resistText;
    [SerializeField] TMP_Text goldText;
    [SerializeField] Image portraitImg;


    private void Update()
    {
        if (SelectedEnemy != null)
        {
            SelectedEnemyScript=SelectedEnemy.GetComponent<enemy_script>();
            CurrentHP=Mathf.RoundToInt(SelectedEnemyScript.hp);
            portraitImg.sprite = SelectedEnemyScript.portrait;
            nameText.text = enemyInfoName;
            hpText.text = "HP:   " + CurrentHP + "/" + enemyInfoMaxHp;
            spdText.text = "SPD:     " + enemyInfoSpd;
            dmgText.text = "DMG:  " + SelectedEnemyScript.dmg;
            armorText.text = "Armor:   " + SelectedEnemyScript.armor;
            resistText.text="Resist:     "+SelectedEnemyScript.resist;
            goldText.text = "Gold:    " + SelectedEnemyScript.gold;
        }

    }

}
