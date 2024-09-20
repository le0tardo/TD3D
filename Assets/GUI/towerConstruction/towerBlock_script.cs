using UnityEngine;

public class towerBlock_script : MonoBehaviour
{
    BoxCollider triggerBox;

    private void Start()
    {
        triggerBox = GetComponentInChildren<BoxCollider>();
    }

    public void Occupy()
    {
        triggerBox.enabled = false;
    }
    public void Clear()
    {
        triggerBox.enabled=true;
    }
}
