using System.Collections;
using UnityEngine;

public class enemyColor_script : MonoBehaviour
{
    public Renderer enemyRenderer;
    private Color originalColor;
    private Color hitColor = new Color(0.89f,0.24f,0.15f);
    private Color freezeColor = new Color(1.41f,1.78f,2.27f);
    private Color poisonColor = new Color(1.17f,1.7f,0.36f);
    public float flashDuration = 0.05f;

    void Start()
    {
        enemyRenderer=GetComponent<Renderer>(); //in children or assign in editor for other meshes...
        originalColor = enemyRenderer.material.color;
    }

    public void FlashRed()
    {
        //Debug.Log("flashing red on hit");
        StartCoroutine(FlashRedRoutine());
    }

    private IEnumerator FlashRedRoutine()
    {
        enemyRenderer.material.color = hitColor/1.5f;
        yield return new WaitForSeconds(flashDuration);
        enemyRenderer.material.color = originalColor;
    }
}
