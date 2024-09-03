using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement_script : MonoBehaviour
{

    public float spd = 3;
    bool canRotate = true;
    public string pathIndex = "";

    private void Update()
    {
        transform.Translate(Vector3.forward * spd * Time.deltaTime);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("wayPoint"))
        {

            wayPoint_script pointScr = other.GetComponent<wayPoint_script>();

            if (pathIndex == "") {pathIndex = pointScr.pathIndex;} //assign path index on first path

            if (canRotate)
            {
                if ((pathIndex == pointScr.pathIndex) || (pointScr.pathIndex==""))//only follow the assigned path OR blank "", all enemies follow blank path indexes!
                { 
                    if (pointScr.turnDirection == true)
                    {
                        transform.Rotate(0, 90, 0);
                    }
                    else
                    {
                        transform.Rotate(0, -90, 0);
                    }
                    canRotate = false;
                    Invoke("CanRotateAgain",1);
                }
            }
        }
    }

    void CanRotateAgain()
    {
        if (!canRotate)
        {
            canRotate = true;
        }
    }
}
