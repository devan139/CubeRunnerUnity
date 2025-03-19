using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnCollisionEnter(Collision Collinfo)
    {
        if(Collinfo.collider.tag == "Obstacle")
        {
            //Debug.Log("We hit an obstacle");
            PlayerMovement.instance.enabled = false;
            PlayerMovement.instance.bc.material = null;

            //endgame function call
            Object.FindFirstObjectByType<GameManager>().endGame();
        }

    }
}
