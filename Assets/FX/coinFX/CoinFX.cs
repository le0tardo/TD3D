using UnityEngine;

public class CoinFX : MonoBehaviour
{
    Animator animator;
    public int flip = 0;
    void Awake()
    {
        animator = GetComponent<Animator>();

    }

    private void OnEnable()
    {
        if (animator == null) { animator = GetComponent<Animator>(); }
        if (flip == 0) { flip = Random.Range(1, 4); }

        switch (flip)
        {
            case 0:
                //no flip
            break;
            case 1:
                animator.Play("flip1",0,0);
            break;
            case 2:
                animator.Play("flip2",0,0);
            break;
            case 3:
                animator.Play("flip3", 0, 0);
            break;
        }
    }


}
