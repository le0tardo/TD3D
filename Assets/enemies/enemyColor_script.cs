using System.Collections;
using UnityEngine;

public class enemyColor_script : MonoBehaviour
{
    public Renderer enemyRenderer;
    private Color originalColor;
    public float flashDuration = 0.1f;

    void Start()
    {
        enemyRenderer=GetComponent<Renderer>(); //in children or assign in editor for other meshes...
        originalColor = enemyRenderer.material.color;
    }

    public void FlashRed()
    {
        Debug.Log("flashing red on hit");
        StartCoroutine(FlashRedRoutine());
    }

    private IEnumerator FlashRedRoutine()
    {
        enemyRenderer.material.color = Color.red;
        yield return new WaitForSeconds(flashDuration);
        enemyRenderer.material.color = originalColor;
    }
}
