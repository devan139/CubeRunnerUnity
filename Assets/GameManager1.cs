using UnityEngine;

public class GameManager1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static GameManager1 Instance { get; private set; }
    public float obstacleSpeed = 23f;
    public GameObject[] obstaclePrefabs;
    public Transform player;
    public float destroyDistance = -10f;
    private int Score = 0;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        if (GameManager1.Instance.obstaclePrefabs.Length != 4)
        {
            Debug.LogError("Please assign exactly 4 prefabs to the Obstacle Prefabs array!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyObstacles()
    {
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach (GameObject obstacle in obstacles)
        {
            if (obstacle.transform.position.z < -10)
            {
                Destroy(obstacle);
            }
        }
    }

    public void AddScore()
    {
        Score += 1;
        Debug.Log($"Score: {Score}");
        Debug.Log("Hello");
    }
}










/*























* 

### Setup Assumptions
- Your prefabs are obstacle types (e.g., `prefab1`, `prefab2`, `prefab3`, `prefab4`).
- The ground is a flat plane along the X-Z plane.
- The main cube (player) moves sideways (X-axis) and stays at a fixed Z position (e.g., Z = 0).
- Obstacles move toward the player (negative Z direction) or the player moves forward, and you want them spawned ahead.

### Steps and Code

#### 1. Create a Spawner Script
Attach this script to an empty GameObject in your scene (e.g., call it "ObstacleSpawner"). This will handle spawning and managing the prefabs.

```csharp
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; // Array to hold your 4 prefabs
    public float spawnDistance = 10f;    // Distance ahead of player to spawn
    public float spaceBetween = 5f;      // Space between prefabs horizontally (X-axis)
    public float destroyDistance = -10f; // Z position where objects are destroyed
    public float spawnInterval = 2f;     // Time between spawns
    public Transform player;             // Reference to the main cube

    private float nextSpawnTime;

    void Start()
    {
        if (obstaclePrefabs.Length != 4)
        {
            Debug.LogError("Please assign exactly 4 prefabs to the Obstacle Prefabs array!");
        }
        nextSpawnTime = Time.time + spawnInterval;
    }

    void Update()
    {
        // Spawn obstacles at intervals
        if (Time.time >= nextSpawnTime)
        {
            SpawnObstacles();
            nextSpawnTime = Time.time + spawnInterval;
        }

        // Destroy obstacles that pass the destroyDistance
        DestroyOutOfBounds();
    }

    void SpawnObstacles()
    {
        // Calculate spawn position based on player's Z position
        float spawnZ = player.position.z + spawnDistance;
        float startX = -spaceBetween * 1.5f; // Center 4 prefabs around X = 0

        for (int i = 0; i < 4; i++)
        {
            // Randomly pick one of the 4 prefabs
            int randomIndex = Random.Range(0, obstaclePrefabs.Length);
            Vector3 spawnPos = new Vector3(startX + (i * spaceBetween), 0, spawnZ);

            // Instantiate the prefab
            GameObject obstacle = Instantiate(obstaclePrefabs[randomIndex], spawnPos, Quaternion.identity);
            obstacle.tag = "Obstacle"; // Tag for easy identification
        }
    }

    void DestroyOutOfBounds()
    {
        // Find all obstacles and destroy those beyond the destroyDistance
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach (GameObject obstacle in obstacles)
        {
            if (obstacle.transform.position.z < player.position.z + destroyDistance)
            {
                Destroy(obstacle);
            }
        }
    }
}
```

#### 2. Configure the Scene
1. **Create the Spawner**:
   - Add an empty GameObject named "ObstacleSpawner".
   - Attach the `ObstacleSpawner` script to it.

2. **Assign Variables in Inspector**:
   - Drag your 4 prefabs into the `Obstacle Prefabs` array (size it to 4 in the Inspector).
   - Set `Player` to your main cube GameObject.
   - Adjust `spawnDistance`, `spaceBetween`, `destroyDistance`, and `spawnInterval` to fit your game’s feel.

3. **Tag the Prefabs**:
   - Open each prefab, set its tag to "Obstacle" (create this tag in Unity if it doesn’t exist).

#### 3. Move the Obstacles or Player
You need relative motion. Here are two options:

- **Option A: Move Obstacles Toward Player**  
  Add this script to each prefab (or create a base `Obstacle` script and apply it):
  ```csharp
  using UnityEngine;

  public class Obstacle : MonoBehaviour
  {
      public float speed = 5f; // Speed obstacles move toward player

      void Update()
      {
          transform.Translate(Vector3.back * speed * Time.deltaTime); // Move along -Z
      }
  }
  ```
  - The player stays at Z = 0 and moves side-to-side (X-axis).

- **Option B: Move Player Forward**  
  If the player moves forward (Z-axis), update the player’s movement script instead, and keep obstacles static:
  ```csharp
  public class PlayerMovement : MonoBehaviour
  {
      public float forwardSpeed = 5f;
      public float sideSpeed = 5f;

      void Update()
      {
          // Move forward
          transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

          // Sideways movement (e.g., with arrow keys)
          float sideInput = Input.GetAxis("Horizontal");
          transform.Translate(Vector3.right * sideInput * sideSpeed * Time.deltaTime);
      }
  }
  ```

#### 4. Test and Adjust
- Play the scene. You should see:
  - Four prefabs spawn randomly at `spawnDistance` ahead of the player.
  - They’re spaced horizontally by `spaceBetween`.
  - They either move toward the player or appear as the player moves forward.
  - They get destroyed when they reach `destroyDistance` behind the player.
- Tweak the variables (`spawnInterval`, `speed`, etc.) to match your desired pacing.

### Notes
- If your ground or cube uses a different Y-level, adjust the `spawnPos.y` in `SpawnObstacles()` accordingly (e.g., `new Vector3(..., 0.5f, ...)` if the cube sits at Y = 0.5).
- For better performance, consider object pooling instead of `Instantiate`/`Destroy`, but this is fine for a simple prototype.
- If you want the prefabs to spawn in a specific order occasionally, modify the `randomIndex` logic.

Let me know if you run into issues or need further clarification!
*/