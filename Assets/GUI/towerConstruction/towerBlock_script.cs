using UnityEngine;

public class towerBlock_script : MonoBehaviour
{
    BoxCollider triggerBox;
    public GameObject triggerObj;
    private void Start()
    {
        if (triggerObj == null)
        { 
            triggerBox = GetComponentInChildren<BoxCollider>();
        }
        else
        {
            triggerBox=triggerObj.GetComponent<BoxCollider>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("prop"))
        {
            Occupy();
        }
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
