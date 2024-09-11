using Unity.VisualScripting;
using UnityEngine;

public class shooterScript : MonoBehaviour
{
    public GameObject target = null;
    public GameObject projectile;
    towerScript twrScr;
    public float coolDown=1.0f;
    Animator animator;

    private void Start()
    {
        twrScr=GetComponentInParent<towerScript>();

        float randomDelay = Random.value;
        InvokeRepeating("Fire", randomDelay, coolDown);

        animator=GetComponentInChildren<Animator>();
        if (animator != null) { animator.Play("idle", 0, 0); }
    }

    private void Update()
    {
        if (twrScr.target != null)
        {
            target = twrScr.target;
        }
        else
        {
            target = null;
        }

        if (target != null)
        {
            //rotate towards target
            Vector3 dir=target.transform.position-transform.position;
            Quaternion qRot = Quaternion.LookRotation(dir);
            Vector3 rot = qRot.eulerAngles;
            transform.rotation = Quaternion.Euler(0f,rot.y,0f);
        }
        else
        {
            //return to originalDirection? nah, looks fine
        }
    }

    void Fire()
    {
        if (target != null && target.activeSelf)
        {
            if (!projectile.activeSelf) 
            {
                projectile.SetActive(true); //projectile[i] set active!

                if (animator != null) { animator.Play("atk", 0, 0); }
            }
        }
        else
        {
            if (animator != null) {
                animator.Play("idle");
            }
        }
    }

    void AttackEvent() //call from animation event?
    {
        if (target != null && target.activeSelf)
        {
            if (!projectile.activeSelf)
            {
                projectile.SetActive(true);
            }
        }
    }

}
