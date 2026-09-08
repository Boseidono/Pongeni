using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float ballSpeed = 8f;
    public float minY = -2.5f;
    public int score = 0;
    public int lives = 5;
    public TMP_Text scoreText;
    public GameObject[] livesImage;
    public GameObject youWinPanel;
    public int brickCount;
    public GameObject gameOverPanel;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.down * ballSpeed; 
    }

    // Update is called once per frame
    void Update()
    {
            if (transform.position.y < minY)
        {
            if (lives <= 0)
            {
                gameOverPanel.SetActive(true);
                Time.timeScale = 0;
            }else
            {
                ResetBall();
                lives = lives - 1;
                livesImage[lives].SetActive(false);
            }
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetBall();
        }
    }
    public void ResetBall()
    {
        transform.position = Vector3.zero;
        rb.linearVelocity = Vector2.down * ballSpeed;

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Row1Brick") || collision.gameObject.CompareTag("Row2Brick") || collision.gameObject.CompareTag("Row3Brick") || collision.gameObject.CompareTag("Row4Brick") || collision.gameObject.CompareTag("Row5Brick"))
        {
            collision.gameObject.SetActive(false);

            score = score + 10;
            scoreText.text = score.ToString("0");
            brickCount = brickCount - 1;

            if (brickCount <= 0)
            {
                youWinPanel.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}
