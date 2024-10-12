using UnityEngine;

public class FIreDamage : MonoBehaviour
{
    enemy_script enmScr;
    void Start()
    {
        enmScr=GetComponentInParent<enemy_script>();
        InvokeRepeating("TakeFireDamage",0,0.5f);
    }

    void TakeFireDamage()
    {
        if (gameObject.activeInHierarchy)
        {
            enmScr.TakeMagicDamage(1);
        }
    }
}
