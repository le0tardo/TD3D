using UnityEngine;

public class billboardGUI_script : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        transform.LookAt(mainCamera.transform);
        transform.Rotate(0, 180, 0);

        // flattens along local x-axis
        //Vector3 directionToCamera = mainCamera.transform.position - transform.position;
        //directionToCamera.y = 0;
        //Quaternion targetRotation = Quaternion.LookRotation(directionToCamera);
        //Quaternion finalRotation = Quaternion.Euler(0, targetRotation.eulerAngles.y + 180, transform.rotation.eulerAngles.z);
        //transform.rotation = finalRotation;
    }
}
