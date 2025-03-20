using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    
    public float spawnInterval = 2f;
    private float nextSpawnTime;
    public float spawnDistance = 1f;

    void Start()
    {
        nextSpawnTime = Time.time + spawnInterval;


    }


    void Update()
    {
        if (Time.time > nextSpawnTime) // && gamemanager.object.active is true, 
        {
            SpawnObstacles();
            nextSpawnTime = Time.time + spawnInterval;
        }
        GameManager1.Instance.DestroyObstacles();
    }
    void SpawnObstacles()
    {

        //float spawnZ = spawnDistance;
        int randomIndex = Random.Range(0, 4);

        Vector3 spawnPos = new Vector3(0, 0, spawnDistance);
        

        // Instantiate the prefab
        GameObject obstacle = Instantiate(GameManager1.Instance.obstaclePrefabs[randomIndex], spawnPos, Quaternion.identity);
        obstacle.tag = "Obstacle";
        
    }

    
}
