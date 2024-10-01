using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshRuleTile : MonoBehaviour
{
    public GameObject[] tiles; // Array of game objects to activate
    float checkRadius = 1f; // Radius to check for neighboring tiles
    string targetTag = "ruleTile"; // Tag to check for neighboring tiles

    public bool xpFree;
    public bool xmFree;
    public bool zpFree;
    public bool zmFree;

    void Start()
    {
        tiles[0].SetActive(false);
        CheckNeighbors();
    }

    void CheckNeighbors()
    {
        // Reset all booleans to true (no neighbors by default)
        xpFree = true;
        xmFree = true;
        zpFree = true;
        zmFree = true;

        // OverlapSphere to find nearby neighbors
        Collider[] neighbors = Physics.OverlapSphere(transform.position, checkRadius);

        // Loop through all nearby objects
        foreach (Collider neighbor in neighbors)
        {
            if (neighbor.CompareTag(targetTag) && neighbor.gameObject != this.gameObject&&neighbor.transform.position.y==transform.position.y)
            {
                Vector3 directionToNeighbor = neighbor.transform.position - transform.position;

                // Check in the positive X direction (x+)
                if (directionToNeighbor.x > 0.1f && Mathf.Abs(directionToNeighbor.z) < 0.1f)
                {
                    xpFree = false; // There's a neighbor in the positive X direction
                }
                // Check in the negative X direction (x-)
                else if (directionToNeighbor.x < -0.1f && Mathf.Abs(directionToNeighbor.z) < 0.1f)
                {
                    xmFree = false; // There's a neighbor in the negative X direction
                }
                // Check in the positive Z direction (z+)
                else if (directionToNeighbor.z > 0.1f && Mathf.Abs(directionToNeighbor.x) < 0.1f)
                {
                    zpFree = false; // There's a neighbor in the positive Z direction
                }
                // Check in the negative Z direction (z-)
                else if (directionToNeighbor.z < -0.1f && Mathf.Abs(directionToNeighbor.x) < 0.1f)
                {
                    zmFree = false; // There's a neighbor in the negative Z direction
                }
            }
        }
        AssignTile();
    }

    void AssignTile() 
    {
        if (xpFree && xmFree && zpFree && zmFree)
        {
            tiles[0].SetActive(true);
        }
        else if (xpFree)
        {
            if (zpFree)
            {
                tiles[7].SetActive(true);
            }
            else if (zmFree)
            {
                tiles[9].SetActive(true);
            }
            else 
            {
                tiles[2].SetActive(true);
            }

        }
        else if (xmFree)
        {
            if (zpFree) { tiles[6].SetActive(true); }
            else if (zmFree) { tiles[8].SetActive(true); }
            else { tiles[3].SetActive(true); }

        }
        else if (zpFree)
        {
            tiles[4].SetActive(true);
        }
        else if (zmFree)
        {
            tiles[5].SetActive(true);
        }
        else
        {
            tiles[1].SetActive(true);
        }
    }
}
