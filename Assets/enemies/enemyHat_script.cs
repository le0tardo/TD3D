using UnityEngine;

public class enemyHat_script : MonoBehaviour
{
    public GameObject[] hats;
    int n;

    private void Start()
    {
        n=Random.Range(0,hats.Length);
        hats[n].SetActive(true);
    }
}
