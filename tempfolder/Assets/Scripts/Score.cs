using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    void Start()
    {

    }


    void Update()
    {
        scoreText.text = PlayerMovement.instance.rb.position.z.ToString("0");
    }
}
