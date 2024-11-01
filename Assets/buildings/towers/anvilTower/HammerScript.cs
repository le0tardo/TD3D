using UnityEngine;

public class HammerScript : MonoBehaviour
{
    public AudioClip hammerTing;
    public float animOffset = 0;
    
    Animator animator;
    GameObject gameMasterObj;
    AudioSource source;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("hammerHit", -1,animOffset);

        gameMasterObj = GameObject.Find("GameMaster");
        source= gameMasterObj.GetComponent<AudioSource>();
    }

    public void PlayHammerSound()
    {
        if (source != null) { source.PlayOneShot(hammerTing); }
    }
}
