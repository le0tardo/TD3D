using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class enemy_script : MonoBehaviour
{
    public string enemyName="Default Enemy";
    public float hp = 1;
    public float maxHp;
    public float dmg = 1;
    public float gold = 1;

    public TextMeshProUGUI hpText;
    public Image hpBackg;
    public Image hpBar;

    //status conditions
    public bool psn = false;
    public bool frz = false;
    public bool brn = false;
    void Start()
    {
        maxHp = hp;
    }

    void Update()
    {
        hpText.text= hp + "/" + maxHp.ToString();
        hpBar.fillAmount = hp / maxHp;

        if (hp < 0) { hp = 0;}
        if (hp > maxHp) {  hp = maxHp; }

        if (hp == maxHp){hpBackg.enabled = false;hpBar.enabled = false; }
        else {hpBackg.enabled = true;hpBar.enabled = true; }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("endPoint"))
        {
            playerStats_script.playerHealth -= dmg;
            Destroy(this.gameObject);
        }
    }
}
