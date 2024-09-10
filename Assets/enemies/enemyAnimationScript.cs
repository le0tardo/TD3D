using UnityEngine;

public class enemyAnimationScript : MonoBehaviour
{
    Animator animator;
    enemy_script enmScr;
    enemyMovement_script enmMoveScr;
    bool isDead=false;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        enmScr = GetComponent<enemy_script>();
        enmMoveScr = GetComponent<enemyMovement_script>();

        animator.speed = enmMoveScr.spd;
        if (animator.speed < 1){animator.speed = 1;}

        int d = Random.Range(1, 5);
        animator.SetInteger("death",d);
        RandomStartFrame();
    }
    private void Update()
    {
        if(enmScr.hp<=0 && isDead ==false)
        {
            isDead = true;
            Die();
        } 
    }
    void Die()
    {
        animator.SetBool("isDead", true);
    }

    void RandomStartFrame()
    {
        AnimatorStateInfo currentState = animator.GetCurrentAnimatorStateInfo(0);
        float randomStart = Random.Range(0f, 1f);
        animator.Play(currentState.fullPathHash, 0, randomStart);
    }
}
