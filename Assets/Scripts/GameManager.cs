using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay=2f;
    public void endGame()
    {
        if (!gameHasEnded)
        {
            Debug.Log("Game Over");
            gameHasEnded = true;
            Invoke("Restart", restartDelay);
        }
        
    }
    public void CompleteLevel()
    {
        Debug.Log("Level Complete");
        //Object.FindFirstObjectByType<GameManager>().CompleteLevel();
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
