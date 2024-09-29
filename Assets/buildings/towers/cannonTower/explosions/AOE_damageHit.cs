using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class AOE_damageHit : MonoBehaviour
{
    public float radius=1; 
    public float dmg=1;
    public ParticleSystem fireFX;
    public ParticleSystem smokeFX;

    private void OnEnable()
    {
        fireFX.Play();
        smokeFX.Play();

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.CompareTag("enemy"))
            {
                enemy_script enmScr=collider.gameObject.GetComponent<enemy_script>();
                enmScr.TakeDamage(dmg);
                Debug.Log("dealt damage: "+dmg + " to "+enmScr.enemyName);
            }
        }
        Invoke("Sleep",0.5f);
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
