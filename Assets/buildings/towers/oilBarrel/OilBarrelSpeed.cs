using UnityEngine;

public class OilBarrelSpeed : MonoBehaviour
{
    towerScript twrScr;
    towerScriptableObjectScript scriptableObj;
    Animator anim;
    void Start()
    {
        twrScr = GetComponentInParent<towerScript>();
        scriptableObj = twrScr.towerStatObj;
        anim = GetComponent<Animator>();

        switch (scriptableObj.towerLevel)
        {
            case 1:
                anim.speed = 0.75f;
            break;
            case 2:
                anim.speed = 1f;
            break;
            case 3:
                anim.speed = 1.25f;
            break;
        }
    }
}
