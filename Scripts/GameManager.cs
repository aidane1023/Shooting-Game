using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyBasicPrefab;
    public GameObject enemyAdvancedPrefab;
    public GameObject cloudPrefab;
    public GameObject coinPrefab;
    public GameObject heartPrefab;
    public GameObject gameOverSet;
    public int screenMove;
    public int score;
    public float moveSpeed;
    public bool blocking;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI powerupText;
    private bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
        CreatSky();
        screenMove = 1;
        score = 0;
        moveSpeed = 4f;
        blocking = false;
        livesText.text = "Lives: 3";
        scoreText.text = "Score: " + score;
        InvokeRepeating("CreateBasic", 1.0f, 2.0f);
        InvokeRepeating("CreateAdvanced", 6.0f, 5.0f);
        InvokeRepeating("CreateCollectable", 1.0f, 5.0f);
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && isGameOver)
        {
            SceneManager.LoadScene("Game");
        }
    }

    void CreateBasic()
    {
        Instantiate(enemyBasicPrefab, new Vector3(Random.Range(-8, 8), 7, 0), Quaternion.identity);
    }

    void CreateAdvanced()
    {
        Instantiate(enemyAdvancedPrefab, new Vector3(Random.Range(-8, 8), 7, 0), Quaternion.identity);
    }

    void CreateCollectable()
    {
        int temp = Random.Range(0,4);
        if(temp == 0) 
        {
            Instantiate(heartPrefab, new Vector3(Random.Range(-8, 8), 7, 0), Quaternion.identity);
        }
        else
        {
            Instantiate(coinPrefab, new Vector3(Random.Range(-8, 8), 7, 0), Quaternion.identity);
        }

    }

    void CreatSky()
    {
        for (int i=0; i < 30; i++)
        {
            Instantiate(cloudPrefab, new Vector3(Random.Range(-11f, 11f), Random.Range(-7.5f, 7.5f), 0), Quaternion.identity);
        }
    }

    public void GameOver()
    {
        CancelInvoke();
        screenMove = 0;
        gameOverSet.SetActive(true);
        GetComponent<AudioSource>().Stop();
        isGameOver = true;
    }

    public void EarnScore(int scoreToAdd)
    {
        score = score + scoreToAdd;
        scoreText.text = "Score: " + score;
    }
}
