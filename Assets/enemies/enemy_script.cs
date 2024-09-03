using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_script : MonoBehaviour
{
    public string enemyName="Default Enemy";
    public float hp = 1;
    public float maxHp;
    public float dmg = 1;
    public float gold = 1;

    void Start()
    {
        maxHp = hp;
    }

    // Update is called once per frame
    void Update()
    {
        
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
