using UnityEngine;
using UnityEngine.Rendering;

public class chickenColor_script : MonoBehaviour
{
    public Texture col1;
    public Texture col2;
    private Material chickenMat;
    int r;

    private void Start()
    {
        chickenMat = GetComponent<Renderer>().material;
        r = Random.Range(0, 2);

        switch (r)
        {
            case 0:
                chickenMat.mainTexture = col1;
                break;
            case 1:
                chickenMat.mainTexture = col2;
                break;
        }
        
    }
}
