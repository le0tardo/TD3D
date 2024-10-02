using UnityEngine;

public class propScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ruleTile"))
        {
            Debug.Log("tree on tile!!!");
        }
    }
}
