using UnityEngine;

public class AddTowerToList_script : MonoBehaviour
{
    gizmoScript gzmScr;

    private void Start()
    {
        gzmScr = GetComponentInParent<gizmoScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("towerRayCast"))
        {
            towerScript twrToAddScr = other.gameObject.GetComponent<towerScript>();
            if (twrToAddScr.towerType != towerType.Gizmo)
            {
                gzmScr.AddToList(other.gameObject);
            }
        }
    }
}
