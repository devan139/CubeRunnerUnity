using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance { get; private set; }
    public Rigidbody rb;
    public BoxCollider bc;
    public float forwardForce = 1500f;
    public float sidewaysForce = 500f;
    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        if (instance != null  && instance!= this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
    }
    void Start()
    {
        if (rb==null)
        {
            rb = GetComponent<Rigidbody>();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce*Time.deltaTime);

        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if(rb.position.y <1f || rb.position.x>8 || rb.position.x<-8)
        {
            Object.FindFirstObjectByType<GameManager>().endGame();
        }
    }
}
