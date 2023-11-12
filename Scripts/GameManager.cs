using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyBasicPrefab;
    public GameObject enemyAdvancedPrefab;
    public GameObject cloudPrefab;
    public GameObject coinPrefab;
    public int screenMove;
    public int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
        CreatSky();
        screenMove = 1;
        score = 0;
        scoreText.text = "Score: " + score;
        InvokeRepeating("CreateBasic", 1.0f, 3.0f);
        InvokeRepeating("CreateAdvanced", 6.0f, 6.0f);
        InvokeRepeating("CreateCoin", 0.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateBasic()
    {
        Instantiate(enemyBasicPrefab, new Vector3(Random.Range(-8, 8), 7, 0), Quaternion.identity);
    }

    void CreateAdvanced()
    {
        Instantiate(enemyAdvancedPrefab, new Vector3(Random.Range(-8, 8), 7, 0), Quaternion.identity);
    }

    void CreateCoin()
    {
        Instantiate(coinPrefab, new Vector3(Random.Range(-8, 8), 7, 0), Quaternion.identity);
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
    }

    public void EarnScore(int scoreToAdd)
    {
        score = score + scoreToAdd;
        scoreText.text = "Score: " + score;
    }
}
