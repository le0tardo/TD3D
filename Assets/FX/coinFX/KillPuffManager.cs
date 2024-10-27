using UnityEngine;

public class KillPuffManager : MonoBehaviour
{
    public static GameObject[] killPuffs;
    public GameObject[] killPuffsAssigned;

    private void Awake()
    {
        killPuffs = killPuffsAssigned;
    }

    public static void ActivateKillPuff(Vector3 spawnPos)
    {
        for (int i = 0;i<killPuffs.Length;i++)
        {
            if (!killPuffs[i].activeInHierarchy)
            {
                killPuffs[i].SetActive(true);
                killPuffs[i].transform.position = spawnPos;
                break;
            }
        }
    }
}
