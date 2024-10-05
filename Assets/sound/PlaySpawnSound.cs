using UnityEngine;

public class PlaySpawnSound : MonoBehaviour
{
    AudioSource source;
    void Start()
    {
        source= GetComponent<AudioSource>();
        source.Play();
    }
}
