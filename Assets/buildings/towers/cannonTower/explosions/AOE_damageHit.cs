using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class AOE_damageHit : MonoBehaviour
{
    public GameObject myTower;
    towerScript myTwrScr;
    public float radius=1; 
    public float dmg=1;
    public ParticleSystem fireFX;
    public ParticleSystem smokeFX;

    Animator lightAnim;

    private void Awake()
    {
        lightAnim = GetComponentInChildren<Animator>();
    }

    private void OnEnable()
    {
        SetValues();

        fireFX.Play();
        smokeFX.Play();
        if (lightAnim != null) { lightAnim.Play("flash"); }

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.CompareTag("enemy"))
            {
                enemy_script enmScr=collider.gameObject.GetComponent<enemy_script>();
                enmScr.TakeDamage(dmg);
            }
        }
        Invoke("Sleep",0.5f);
    }
    void SetValues()
    {
        myTwrScr = myTower.GetComponent<towerScript>();
        radius = 1+(myTwrScr.towerRange/3);
        dmg = myTwrScr.towerDamage;
        fireFX.transform.localScale = new Vector3(radius/4, radius/4, radius/4);
        smokeFX.transform.localScale = new Vector3(radius/4, radius/4, radius/4);
    }

    void Sleep()
    {
        gameObject.SetActive(false);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}