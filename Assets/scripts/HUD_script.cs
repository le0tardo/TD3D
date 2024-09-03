using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD_script : MonoBehaviour
{
    public TMP_Text healtText;
    public TMP_Text goldText;

    void Update()
    {
        healtText.text="Lives: "+playerStats_script.playerHealth.ToString();
        goldText.text="Gold: "+playerStats_script.playerGold.ToString();
    }
}
