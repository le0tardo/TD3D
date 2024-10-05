using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;

public class shooterScript : MonoBehaviour
{
    public GameObject target = null;
    public GameObject projectile; //make array
    public GameObject[] projectiles;
    towerScript twrScr;
    public float spd;
    public bool atk=false;
    Animator animator;

    private void Start()
    {
        twrScr=GetComponentInParent<towerScript>();
        spd=twrScr.towerSpeed;

        animator=GetComponentInChildren<Animator>();
        float randomFrame = Random.value;
        if (animator != null) { animator.Play("idle", 0, randomFrame); }

        TurnToRoad();
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
            Quaternion smoothedRotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, qRot.eulerAngles.y, 0f), Time.deltaTime * 5);
            transform.rotation = smoothedRotation;

            if (!atk)
            {
                AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
                if (stateInfo.normalizedTime >= 1.0f)
                {
                    Fire();
                    atk = true;
                }
            }
        }
        else
        {
            if (twrScr.targets.Length > 0) 
            { 
                if (atk)
                {
                    AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
                    if (stateInfo.normalizedTime >= 1.0f)
                    { 
                        StopFire();
                        atk = false;
                    }
                }
            }
            else
            {
                StopFire();
                atk = false;
            }
        }
        spd = twrScr.towerSpeed;
    }

    void Fire()
    {
        if (animator != null) { animator.Play("atk"); }
    }
    void StopFire()
    {
        if (animator != null){animator.Play("idle");}
    }
    #region //turn to road
    void TurnToRoad()
    {
        GameObject[] roadBlocks = GameObject.FindGameObjectsWithTag("roadBlock");
        GameObject nearestRoadBlock = FindNearestRoad(roadBlocks);
        if (nearestRoadBlock != null)
        {
            RotateToRoad(nearestRoadBlock.transform);
        }
    }

    GameObject FindNearestRoad(GameObject[] roadBlocks)
    {
        GameObject nearest = null;
        float minDistance = 10;

        foreach (GameObject roadBlock in roadBlocks)
        {
            float distance = Vector3.Distance(transform.position, roadBlock.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearest = roadBlock;
            }
        }

        return nearest;
    }
    void RotateToRoad(Transform target)
    {
        Vector3 direction = target.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Euler(0f, targetRotation.eulerAngles.y, 0f);
        //Debug.Log("rotated towards nearest road!");
    }
    #endregion
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
