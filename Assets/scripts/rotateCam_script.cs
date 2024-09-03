using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class rotateCam_script : MonoBehaviour
{
    public float rotSpd=5.0f;
    public float movSpd = 10.0f;

    public GameObject areaObj;
    BoxCollider area;

    private void Start()
    {
        area=areaObj.GetComponent<BoxCollider>();
    }
    void Update()
    {
        if ((Input.GetMouseButton(1))||(Input.GetMouseButton(2)))
        {
            float mouse_x = Input.GetAxis("Mouse X");
            float rot = mouse_x * rotSpd;
            transform.Rotate(Vector3.up, rot);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.up,0.25f);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up, -0.25f);
        }

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 movement = (transform.right * moveX + transform.forward * moveZ) * movSpd * Time.deltaTime;
        Vector3 newPosition = transform.localPosition + movement;
        if (inArea(newPosition))
        {
            transform.localPosition = newPosition;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            movSpd = 25;
        }
        else
        {
            movSpd = 10;
        }
    }

    private bool inArea(Vector3 position)
    {
        Bounds bounds = area.bounds;
        return bounds.Contains(position);
    }

}
