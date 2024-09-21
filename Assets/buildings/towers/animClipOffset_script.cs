using UnityEditor.Animations;
using UnityEngine;

public class animClipOffset_script : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetFloat("cycleOffset", Random.value);
    }
}
