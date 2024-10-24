using UnityEngine;

public class TowerSound : MonoBehaviour
{
    [SerializeField] AudioClip spawnSnd;
    [SerializeField] AudioClip boostSnd; //boost sound played by gizmo tower
    [SerializeField] AudioClip killSnd;
    [SerializeField] AudioClip atkSnd;
    [SerializeField] AudioClip hitSnd;

    private AudioSource source;
    private AudioSource globalSource;
    GameObject globalAudio;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        if (spawnSnd != null) { source.PlayOneShot(spawnSnd); }

        globalAudio = GameObject.Find("globalAudio");
        globalSource = globalAudio.AddComponent<AudioSource>();
    }

    public void PlayAttackSound()
    {
        if (globalSource != null)
        { 
            globalSource.pitch = Random.Range(0.8f, 1.2f);
            if (atkSnd != null) { globalSource.PlayOneShot(atkSnd); }
        }
    }

    public void PlayHitSound()
    {
        if (globalSource != null)
        {
            globalSource.pitch = Random.Range(0.8f,1.2f);
            if (hitSnd != null) { globalSource.PlayOneShot(hitSnd); }
        }
    }

    public void PlayDestroySound()
    {
        if (killSnd != null) { globalSource.PlayOneShot(killSnd); }
    }

    public void PlayBoostSound()
    {
        if (boostSnd != null) { source.PlayOneShot(boostSnd); }
    }
        
}
