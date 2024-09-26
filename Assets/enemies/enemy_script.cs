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
    public float armor;
    public float resist;
    public float dmg = 1;
    public float gold = 1;
    public Sprite portrait;

    public TextMeshProUGUI hpText;
    public Image hpBackg;
    public Image hpBar;

    //status conditions
    public bool psn = false;
    public bool frz = false;
    public bool brn = false;

    public GameObject killPuff;
    bool isDead = false;
    void Start()
    {
        maxHp = hp;

        //random lane position and snap to ground road height
        float rOffset = Random.Range(-0.33f,0.33f);
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z+rOffset);
        transform.position = new Vector3(transform.position.x, 0.7f, transform.position.z);
    }

    void Update()
    {
        hpText.text= hp + "/" + maxHp.ToString();
        hpBar.fillAmount = hp / maxHp;

        if (hp < 0) { hp = 0;}
        if (hp > maxHp) {  hp = maxHp; }

        if (hp == maxHp){hpBackg.enabled = false;hpBar.enabled = false; }
        else {hpBackg.enabled = true;hpBar.enabled = true; }

        if(hp<=0 && isDead == false)
        {
            Die();
            isDead = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("endPoint"))
        {
            //playerStats_script.playerHealth -= dmg;
            GameObject endPoint = other.gameObject;
            pathEnd_script endScr=endPoint.GetComponent<pathEnd_script>();
            endScr.TakeDamage(dmg);
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage(float hitDmg)
    {
        hitDmg -= armor;
        if (hitDmg > 0) { hp -= hitDmg; }
        enemyColor_script clrScr=GetComponent<enemyColor_script>();
        clrScr.FlashRed();
    }

    public void TakeMagicDamage(float hitDmg)
    {
        hitDmg -= resist;
        if (hitDmg > 0) { hp -= hitDmg; }
        enemyColor_script clrScr = GetComponent<enemyColor_script>();
        clrScr.FlashRed();
    }

    void Die()
    {
        enemyMovement_script moveScr=GetComponent<enemyMovement_script>();
        moveScr.spd = 0;
        Invoke("Recycle", 0.3f);
    }
    void Recycle()
    {
        //find spawn point
        //warp to spawn
        //this.gameObject.SetActive(false);
        if (killPuff != null) { Instantiate(killPuff, transform.position, Quaternion.identity); }
        playerStats_script.playerGold += gold;
        Destroy(this.gameObject);
    }
}
