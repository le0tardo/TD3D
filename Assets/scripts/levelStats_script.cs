using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelStats_script : MonoBehaviour
{
    public float health = 1;
    public float gold = 1;

    private void Awake()
    {
        playerStats_script.playerHealth = health;
        playerStats_script.playerGold = gold;
    }
}
