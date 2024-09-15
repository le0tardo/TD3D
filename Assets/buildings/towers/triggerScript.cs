using UnityEngine;

public class triggerScript : MonoBehaviour
{
    shooterScript shooter;
    public void TriggerAttack()
    {
        shooter=GetComponentInParent<shooterScript>();
        if (shooter != null)
        {
            shooter.AttackEvent();
        }
    }
}
