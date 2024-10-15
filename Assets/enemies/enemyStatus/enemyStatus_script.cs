using System.Collections;
using UnityEngine;

public class enemyStatus_script : MonoBehaviour
{
    public GameObject fire;

    enemy_script enemyScr;
    enemyMovement_script moveScr;
    enemyColor_script colorScr;

    float defaultSpd;
    float frzSpd;

    float currentPoisonLevel = 0;
    float psnTick = 2.5f;

    private void Start()
    {
        enemyScr = GetComponent<enemy_script>();
        moveScr = GetComponent<enemyMovement_script>();
        colorScr = GetComponent<enemyColor_script>();

        defaultSpd = moveScr.spd;
        frzSpd = moveScr.spd / 2;
    }
    public void Poison(int psn)
    {
        if (psn > currentPoisonLevel) {  currentPoisonLevel = psn; }
        InvokeRepeating("DealPoisonDamge", psnTick, psnTick);
    }

    void DealPoisonDamge()
    {
        enemyScr.hp -= currentPoisonLevel;
        colorScr.FlashPurple();
    }

    public void Burn(int burnTime)
    {
        if (fire != null)
        {
            fire.SetActive(true);
            CancelInvoke("StopBurn");
            Invoke("StopBurn",burnTime);
            //deal actual damage in fire object? while active, coroutine hp--;
        }
    }

    void StopBurn()
    {
        fire.SetActive(false);
    }

    public void Freeze(int time)
    {
        StartCoroutine(FreezeRoutine(time));
        colorScr.TurnBlue(time);
    }

    IEnumerator FreezeRoutine(int t)
    {
        moveScr.spd = frzSpd;
        yield return new WaitForSeconds(t);
        moveScr.spd = defaultSpd;
    }
}
