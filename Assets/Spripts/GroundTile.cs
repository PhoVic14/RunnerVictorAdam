using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] GameObject tallObstaclePrefab;
    [SerializeField] GameObject movingObstaclePrefab;
    [SerializeField] GameObject verticalMovingObstaclePrefab;
    [SerializeField] GameObject forwardBackwardMovingObstaclePrefab;
    [SerializeField] GameObject rampPrefab; // Ajoutez cette ligne
    [SerializeField] float tallObstacleChance = 0.2f;
    [SerializeField] float movingObstacleChance = 0.1f;
    [SerializeField] float verticalMovingObstacleChance = 0.1f;
    [SerializeField] float forwardBackwardMovingObstacleChance = 0.1f;

    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile(true);
        Destroy(gameObject, 2);
    }

    void Update()
    {
    }

    public void SpawnObstacle()
    {
        GameObject obstacleToSpawn = obstaclePrefab;
        float random = Random.Range(0f, 1f);
        if (random < tallObstacleChance)
        {
            obstacleToSpawn = tallObstaclePrefab;
        }
        else if (random < tallObstacleChance + movingObstacleChance)
        {
            obstacleToSpawn = movingObstaclePrefab;
        }
        else if (random < tallObstacleChance + movingObstacleChance + verticalMovingObstacleChance)
        {
            obstacleToSpawn = verticalMovingObstaclePrefab;
        }
        else if (random < tallObstacleChance + movingObstacleChance + verticalMovingObstacleChance + forwardBackwardMovingObstacleChance)
        {
            obstacleToSpawn = forwardBackwardMovingObstaclePrefab;
        }

        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        Vector3 spawnPosition = spawnPoint.position;

        // Ajouter un décalage à la position Y pour lever l'obstacle
        if (obstacleToSpawn == tallObstaclePrefab)
        {
            spawnPosition.y += 1f;
        }

        Instantiate(obstacleToSpawn, spawnPosition, Quaternion.identity, transform);
    }

    public void SpawnCoins()
    {
        int coinsToSpawn = 5;
        for (int i = 0; i < coinsToSpawn; i++)
        {
            GameObject temp = Instantiate(coinPrefab);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
        );
        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }

        point.y = 1;
        return point;
    }
}
