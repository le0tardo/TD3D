using UnityEngine;

public class CoinFXParent : MonoBehaviour
{
    public GameObject coin1;
    public GameObject coin2;
    public GameObject coin3;
    public ParticleSystem puff;

    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        audioSource.Play();
        coin1.SetActive(true);
        coin2.SetActive(true);
        coin3.SetActive(true);
        puff.Play();

        Invoke("DisableMe", 0.66f);
    }
    void DisableMe()
    {
        this.gameObject.SetActive(false);
    }
}
