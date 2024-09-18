using UnityEngine;

public class hitFX_script : MonoBehaviour
{
    ParticleSystem FX;

    private void Start()
    {
        FX= GetComponentInChildren<ParticleSystem>();
    }
    public void Hit(Vector3 spawnPos)
    {
        FX.Play();
        transform.position = spawnPos;
    }
}
