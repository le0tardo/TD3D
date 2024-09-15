using UnityEngine;

public class pathEnd_script : MonoBehaviour
{
    public GameObject arc;
    public GameObject gameOverScreen;
    Animator arcAnim;
    bool gameOver = false;

    private void Start()
    {
        arcAnim=GetComponentInChildren<Animator>();
    }

    public void TakeDamage(float dmg)
    {
        arcAnim.Play("hit",0,0);
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
