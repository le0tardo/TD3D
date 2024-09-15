using UnityEngine;

public class pathEnd_script : MonoBehaviour
{
    public GameObject arc;
    Animator arcAnim;

    private void Start()
    {
        arcAnim=GetComponentInChildren<Animator>();
    }

    public void TakeDamage(float dmg)
    {
        arcAnim.Play("hit",0,0);
        playerStats_script.playerHealth -= dmg;
    }
}
