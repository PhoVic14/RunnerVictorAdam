using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundTile;
    Vector3 nextSpawnPoint;
    
    public void SpawnTile ()
    {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
    }
    // Start is called before the first frame update
    public void Start()
    {
       for (int i = 0; i < 10; i++)
        {
            SpawnTile();
        }
    }
}
