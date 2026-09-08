using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public BallController ballController;
    public Vector2Int size;
    public Vector2 offset;
    public GameObject brickPrefabRow1;
    public GameObject brickPrefabRow2;
    public GameObject brickPrefabRow3;
    public GameObject brickPrefabRow4;
    public GameObject brickPrefabRow5;
    private GameObject newBrick;
    public GameObject youWinPanel;
    public GameObject paddle;
    public GameObject gameOverPanel;
    public GameObject ExitGamePanel;

    // Start is called before the first frame update
    void Start()
    {
        DrawBricks();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !gameOverPanel.activeInHierarchy && !youWinPanel.activeInHierarchy)
        {
            ExitGameOption();
        }
    }

    private void DrawBricks()
    {
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 2; j < size.y; j++)
            {
                switch (j)
                {
                    case 2:
                        newBrick = Instantiate(brickPrefabRow1, transform);
                        break;
                    case 3:
                        newBrick = Instantiate(brickPrefabRow2, transform);
                        break;
                    case 4:
                        newBrick = Instantiate(brickPrefabRow3, transform);
                        break;
                    case 5:
                        newBrick = Instantiate(brickPrefabRow4, transform);
                        break;
                    case 6:
                        newBrick = Instantiate(brickPrefabRow5, transform);
                        break;
                }


                newBrick.transform.position = transform.position + new Vector3((float)((size.x - 1) * .5f - i) * offset.x, j * offset.y, 0);
            }
        }

        ballController.brickCount = transform.childCount;
    }

    private void UnhideBricks()
    {
        for (int i = 0; i <= transform.childCount - 1; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
        ballController.brickCount = transform.childCount;
    }

    public void Restart()
    {
        if (youWinPanel.activeInHierarchy)
        {
            youWinPanel.SetActive(false);
        }
        else
        {
            gameOverPanel.SetActive(false);
        }
        youWinPanel.SetActive(false);

        for (int i = 0; i <= 4; i++)
        {
            ballController.livesImage[i].SetActive(true);
        }

        ballController.lives = 5;
        ballController.score = 0;
        ballController.scoreText.text = ballController.score.ToString("0");
        paddle.transform.position = new Vector3(0, paddle.transform.position.y, paddle.transform.position.z);
        ballController.ResetBall();
        Time.timeScale = 1;
        UnhideBricks();

    }



    private void ExitGameOption()
    {
        Time.timeScale = 0;
        ExitGamePanel.SetActive(true);

    }

    public void ExitProgram()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void NoExit()
    {
        ExitGamePanel.SetActive(false);
        Time.timeScale = 1;
    }
}
