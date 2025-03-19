using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Obstacle")
        {
            Object.FindFirstObjectByType<GameManager>().CompleteLevel();

        }
    }
}





//-----------------------------------------------

//using UnityEngine;

//public class CubeSpawner : MonoBehaviour
//{
//    public GameObject cubePrefab;        // Assign your cube prefab in the Inspector
//    public Transform player;             // Reference to your player object
//    public float spawnDistance = 50f;    // Distance ahead of player to spawn
//    public float moveSpeed = 5f;         // Speed at which prefab moves toward player
//    public float spawnInterval = 2f;     // Time between spawns
//    private float nextSpawnTime;

//    // Ground dimensions
//    private float groundWidth = 15f;
//    private float groundLength = 100f;

//    void Start()
//    {
//        nextSpawnTime = Time.time + spawnInterval;
//    }

//    void Update()
//    {
//        if (Time.time >= nextSpawnTime)
//        {
//            SpawnCubePrefab();
//            nextSpawnTime = Time.time + spawnInterval;
//        }

//        // Move all spawned prefabs towards player
//        foreach (Transform child in transform)
//        {
//            child.position += Vector3.back * moveSpeed * Time.deltaTime;

//            // Destroy prefab when it passes the player
//            if (child.position.z < player.position.z - 5f)
//            {
//                Destroy(child.gameObject);
//            }
//        }
//    }

//    void SpawnCubePrefab()
//    {
//        // Calculate spawn position (centered on X-axis, ahead of player on Z-axis)
//        Vector3 spawnPosition = new Vector3(
//            0f, // Centered on X-axis
//            0f, // Assuming ground level is at y=0
//            player.position.z + spawnDistance
//        );

//        // Instantiate the prefab
//        GameObject spawnedPrefab = Instantiate(cubePrefab, spawnPosition, Quaternion.identity);
//        spawnedPrefab.transform.parent = transform; // Make it a child of spawner for organization

//        // Get all cube children (assuming your prefab has 3 cubes as direct children)
//        Transform[] cubes = spawnedPrefab.GetComponentsInChildren<Transform>();

//        // Filter to only include the actual cube objects (excluding the parent)
//        Transform[] cubeChildren = new Transform[3];
//        int index = 0;
//        foreach (Transform cube in cubes)
//        {
//            if (cube != spawnedPrefab.transform && index < 3)
//            {
//                cubeChildren[index] = cube;
//                index++;
//            }
//        }

//        // Randomly disable one cube
//        int randomIndex = Random.Range(0, 3);
//        cubeChildren[randomIndex].gameObject.SetActive(false);
//    }
//}