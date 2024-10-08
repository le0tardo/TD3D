using System.Collections;
using UnityEngine;

public class enemyStatus_script : MonoBehaviour
{
    enemy_script enemyScr;
    enemyMovement_script moveScr;
    enemyColor_script colorScr;

    float defaultSpd;
    float frzSpd;

    private void Start()
    {
        enemyScr = GetComponent<enemy_script>();
        moveScr = GetComponent<enemyMovement_script>();
        colorScr = GetComponent<enemyColor_script>();

        defaultSpd = moveScr.spd;
        frzSpd = moveScr.spd / 2;
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
