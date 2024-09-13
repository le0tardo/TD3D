using UnityEngine;

public class assignMaterialScript : MonoBehaviour
{
    public Material material;
    public Texture[] texture;

    private Renderer pawnRenderer;

    void Start()
    {
        pawnRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        pawnRenderer.material = material;

        if (texture.Length >1)
        {
            int r=Random.Range(0,texture.Length);
            pawnRenderer.material.mainTexture = texture[r];
        }
        else
        {
            pawnRenderer.material.mainTexture = texture[0];
        }
    }
}
