using UnityEngine;

public class selectEnemyScript : MonoBehaviour
{
    public GameObject selectedEnemy;
    public GameObject enemyMarker;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.collider.gameObject;

                if (hit.collider.gameObject.CompareTag("enemyRayCast"))
                {
                    selectedEnemy = hitObject.transform.parent.gameObject;
                    Debug.Log("Selected enemy: " + selectedEnemy.name);
                }
                else
                {
                    selectedEnemy = null;
                    Debug.Log("Deselected enemy");
                }
            }
        }

        if (selectedEnemy != null)
        {
            enemyMarker.transform.position = new Vector3 (selectedEnemy.transform.position.x,selectedEnemy.transform.position.y+0.1f,selectedEnemy.transform.position.z);
        }
        else
        {
            enemyMarker.transform.position= Vector3.zero;
        }
    }
}
