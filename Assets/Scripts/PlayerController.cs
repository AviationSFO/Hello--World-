using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.1f;
    Rigidbody rb;
    float jumpForce = 13.0f;
    bool jumping = false;
    private int score = 0;
    public bool isDead = false;
    public TextMeshProUGUI scoreObject;
    public TextMeshProUGUI deathObject;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        scoreObject.text = "Score: " + score;
        deathObject.text = "";
        Debug.Log("Started player controller succesfully");
    }

    // Update is called once per frame
    void Update()
    {
        if(!isDead)
        {
            if(Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
            if(Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.back * speed * Time.deltaTime);
            }
            if(Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            if(Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            if(Input.GetKeyDown(KeyCode.Space) && !jumping)
            {
                jumping = true;
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }

            // View Manipulation
            if(Input.GetKey(KeyCode.Q))
            {
                transform.Rotate(Vector3.down * speed*7 * Time.deltaTime);
            }
            if(Input.GetKey(KeyCode.E))
            {
                transform.Rotate(Vector3.up * speed*7 * Time.deltaTime);
            }
            if(Input.GetKey(KeyCode.F))
            {
                transform.Rotate(Vector3.right * speed*5 * Time.deltaTime);
            }
            if(Input.GetKey(KeyCode.R))
            {
                transform.Rotate(Vector3.left * speed*5 * Time.deltaTime);
            }
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Platform"))
        {
            if(jumping)
            {
                jumping = false;
            }
        }
        else if (collision.gameObject.CompareTag("EndPlat"))
        {
            isDead = true;
            deathObject.text = "You Win!";
            if(SceneManager.GetActiveScene().buildIndex < 2) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                SceneManager.LoadScene(0);
            }


        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            Debug.Log("Collided with coin");
            score++;
            scoreObject.text = "Score: " + score;
            Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("Enemy"))
        {
            GameOver();
        }
    }
    public void GameOver()
    {
        isDead = true;
        Debug.Log("Game Over");
        deathObject.text = "Game Over!";
    }
}
