using UnityEngine;

public class rangeDraw_script : MonoBehaviour
{
    LineRenderer circleLine;
    towerScript twrScr;
    float range;

    private void Start()
    {
        circleLine=GetComponent<LineRenderer>();
        twrScr=GetComponent<towerScript>();
        range = twrScr.towerRange;

        DrawCircle(32, range);
    }

    void DrawCircle(int steps, float radius)
    {
        circleLine.positionCount=steps;
        for (int i=0; i<steps; i++)
        {
            float circumference = (float)i / steps;
        }
    }
}
