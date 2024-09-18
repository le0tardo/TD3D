using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD_script : MonoBehaviour
{
    public TMP_Text healtText;
    public TMP_Text goldText;
    public TMP_Text waveText;
    float playerMaxHealth;

    private void Start()
    {
        playerMaxHealth = playerStats_script.playerHealth;

    }

    void Update()
    {
        goldText.text = playerStats_script.playerGold.ToString();
        //healtText.text=playerMaxHealth+"/"+playerStats_script.playerHealth.ToString();
        healtText.text=playerStats_script.playerHealth.ToString();
        waveText.text=playerStats_script.currentWave.ToString()+"/"+playerStats_script.waves.ToString();
    }
}
