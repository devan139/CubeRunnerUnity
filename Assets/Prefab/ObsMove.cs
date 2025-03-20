using UnityEngine;

public class Obstacle : MonoBehaviour
{

    void Update()
    {
        transform.Translate(Vector3.back * GameManager1.Instance.obstacleSpeed * Time.deltaTime); // Move along -Z
    }
}

//change made