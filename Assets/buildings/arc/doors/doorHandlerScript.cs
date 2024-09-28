using UnityEngine;

public class doorHandlerScript : MonoBehaviour
{
    public Mesh[] doors;
    MeshFilter meshFilter;
    int index;
    int lives;
    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        index=doors.Length;
        meshFilter.mesh = doors[index-1];
        lives = Mathf.RoundToInt(playerStats_script.playerHealth);
    }

    // Update is called once per frame
    void Update()
    {
        lives= Mathf.RoundToInt(playerStats_script.playerHealth);

        if (lives <= 0)
        {
            Destroy(gameObject);
        }

        if (index != lives&&index<=doors.Length)
        {
            index= lives;
            meshFilter.mesh= doors[index];
        }
    }
}
