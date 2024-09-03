using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class camZoom_script : MonoBehaviour
{
    float minZoom = 22.5f;
    float maxZoom = 60f;
    float currZoom;

    Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
        currZoom = cam.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if(scroll != 0)
        {
            currZoom += (scroll * -25);
        }
        ZoomBounds();

        if (cam.fieldOfView != currZoom)
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, currZoom, 0.01f);
        }

    }

    void ZoomBounds()
    {
        if (currZoom < minZoom)
        {
            currZoom=minZoom;
        }
        if (currZoom > maxZoom)
        {
            currZoom=maxZoom;
        }
    }
}
