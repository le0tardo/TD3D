using UnityEngine;
using UnityEngine.UI;

public class towerPlaceButton_script : MonoBehaviour
{
    public towerScriptableObjectScript tower;
    public GameObject towerInfoBox;

    private void Start()
    {
        Debug.Log("tower name: "+tower.towerName);
    }
}
