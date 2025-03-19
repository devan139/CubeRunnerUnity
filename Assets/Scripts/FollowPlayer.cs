using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Transform player;
    public Vector3 offset;

    void Update()
    {
        transform.position = PlayerMovement.instance.rb.position + offset;
        //Debug.Log(PlayerMovement.instance.rb.position);

        //Debug.Log(PlayerMovement.instance.rb.position);
    }
}
