using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOver_script : MonoBehaviour
{
    private void OnEnable()
    {
        //prolly need to pause or destroy stuff...
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
