using Unity.VisualScripting;
using UnityEngine;

public class shooterScript : MonoBehaviour
{
    public GameObject target = null;
    public GameObject projectile; //make array
    public GameObject[] projectiles;
    towerScript twrScr;
    public float spd = 1.0f;
    public bool atk=false;
    Animator animator;

    private void Start()
    {
        twrScr=GetComponentInParent<towerScript>();

        animator=GetComponentInChildren<Animator>();
        float randomFrame = Random.value;
        if (animator != null) { animator.Play("idle", 0, randomFrame); }
    }

    private void Update()
    {
        if (animator.speed != spd){animator.speed = spd;}

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

            if (!atk)
            {
                Fire();
                atk = true;
            }
        }
        else
        {
            if (atk)
            {
                StopFire();
                atk = false;
            }
        }
    }

    void Fire()
    {
        if (animator != null) { animator.Play("atk"); }
    }
    void StopFire()
    {
        if (animator != null){animator.Play("idle");}
    }
    
    public void AttackEvent()
    {
        if (target != null && target.activeSelf)
        {
            for (int i = 0;i<projectiles.Length;i++)
            {
                if (!projectiles[i].activeInHierarchy) 
                { 
                    projectiles[i].SetActive(true);
                    break;
                }
            }
        }
    }
}
