using System.Collections;
using UnityEngine;

public class enemyColor_script : MonoBehaviour
{
    public SkinnedMeshRenderer enemyRenderer;
    private Color originalColor;
    private Color hitColor = new Color(0.89f,0.24f,0.15f);
    private Color freezeColor = new Color(1.41f,1.78f,2.27f);
    private Color poisonColor = new Color(1.14f,0.28f,2.12f);
    private Color currentColor;
    public float flashDuration = 0.02f;

    public GameObject prop;
    private MeshRenderer propRenderer;
    private Color propOriginalColor;

    void Start()
    {
        enemyRenderer=GetComponentInChildren<SkinnedMeshRenderer>();
        if(enemyRenderer!=null)originalColor = enemyRenderer.material.color;
        currentColor = originalColor;

        if (prop != null)
        {
            propRenderer = prop.GetComponent<MeshRenderer>();
            propOriginalColor = propRenderer.material.color;
        }
    }

    public void FlashRed()
    {
        if (enemyRenderer != null) StartCoroutine(FlashRedRoutine());
    }

    private IEnumerator FlashRedRoutine()
    {
        enemyRenderer.material.color = hitColor/1.5f;
        if (prop != null) { propRenderer.material.color = hitColor/1.5f;}

        yield return new WaitForSeconds(flashDuration);

        enemyRenderer.material.color = currentColor;
        if (prop != null) { propRenderer.material.color = propOriginalColor;}
    }

    public void FlashPurple()
    {
        if (enemyRenderer != null) StartCoroutine(FlashPurpleRoutine());
    }

    IEnumerator FlashPurpleRoutine()
    {
        enemyRenderer.material.color = poisonColor/1.5f;
        if (prop != null) { propRenderer.material.color = poisonColor/1.5f;}

        yield return new WaitForSeconds(flashDuration);

        enemyRenderer.material.color = currentColor;
        if (prop != null) { propRenderer.material.color = propOriginalColor; }
    }

    public void TurnBlue(int t)
    {
        currentColor = freezeColor/1.5f;
        Invoke("UnturnBlue", t);
    }
    void UnturnBlue()
    {
        currentColor = originalColor;
        enemyRenderer.material.color = currentColor;
    }
}
