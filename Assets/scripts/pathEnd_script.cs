using UnityEngine;

public class pathEnd_script : MonoBehaviour
{
    public GameObject arc;
    public GameObject gameOverScreen;
    public GameObject soundObj;
    public AudioClip hitSnd;
   
    Animator arcAnim;
    bool gameOver = false;
    AudioSource source;

    private void Start()
    {
        arcAnim=GetComponentInChildren<Animator>();
        source=soundObj.GetComponent<AudioSource>();
    }

    public void TakeDamage(float dmg)
    {
        arcAnim.Play("hit",0,0);
        source.PlayOneShot(hitSnd);
        playerStats_script.playerHealth -= dmg;
        
    }

    private void Update()
    {
        if (playerStats_script.playerHealth <= 0)
        {
            if(!gameOver)
            {
                gameOverScreen.SetActive(true);
                gameOver = true;
            }
        }
    }
}
