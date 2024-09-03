using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camTilt_script : MonoBehaviour
{
    public float rotationSpeed = 5.0f;
    private float rotationX;

    private void Start()
    {
        rotationX=transform.localRotation.x;
    }

    private void Update()
    {
        if ((Input.GetMouseButton(1))||(Input.GetMouseButton(2)))
        {
            float mouseY = Input.GetAxis("Mouse Y");
            rotationX -= mouseY * rotationSpeed;
            rotationX = Mathf.Clamp(rotationX, -25f, 25f);
            transform.localRotation = Quaternion.Euler(rotationX, transform.localEulerAngles.y, transform.localEulerAngles.z);
        }
    }
}
