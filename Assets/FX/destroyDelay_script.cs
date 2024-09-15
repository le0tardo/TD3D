using UnityEngine;

public class destroyDelay_script : MonoBehaviour
{
    public int sek = 2;
    private void Start()
    {
        Invoke("DestroyObject",sek);
    }

    void DestroyObject()
    {
        Destroy(this.gameObject);
    }
}
