using UnityEngine;
using TMPro;

public class BuffFX : MonoBehaviour
{
    public Canvas buffCanvas;
    public TMP_Text buffText;
    Camera mainCam;

    private void Start()
    {
        mainCam = Camera.main;
        //buffText.text = "";
        Invoke("Kill", 1);
    }

    private void LateUpdate()
    {
        buffCanvas.transform.LookAt(transform.position + mainCam.transform.rotation * Vector3.forward,mainCam.transform.rotation * Vector3.up);
    }

    void Kill()
    {
       // Destroy(this.gameObject);
    }
}
