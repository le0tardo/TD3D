using UnityEngine;

public class TowerSound : MonoBehaviour
{
    [SerializeField] AudioClip spawnSnd;
    [SerializeField] AudioClip boostSnd; //boost sound played by gizmo tower
    [SerializeField] AudioClip killSnd;
    [SerializeField] AudioClip atkSnd;
    [SerializeField] AudioClip hitSnd;

    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        if (spawnSnd != null) { source.PlayOneShot(spawnSnd); }
    }

    public void PlayAttackSound()
    {
        if (atkSnd != null) { source.PlayOneShot(atkSnd); }
    }

    public void PlayDestroySound()
    {
        if (killSnd != null) { source.PlayOneShot(killSnd); }
    }

    public void PlayBoostSound()
    {
        if (boostSnd != null) { source.PlayOneShot(boostSnd); }
    }
        
}
