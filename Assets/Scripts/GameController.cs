using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject[] hazards;
    public GameObject player;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    //Score variables
    public Text scoreText;
    private int score;

    private List<GameObject> activeHazards = new List<GameObject>();

    public Text gameOverText;
    public Text restartText;
    private bool gameOver;
    private bool restart;

    void Start()
    {
        StartCoroutine(spawnWaves());
        score = 0;
        UpdateScore();

        gameOver = false;
        restart = false;

        restartText.text = "";
        gameOverText.text = "";
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }


    IEnumerator spawnWaves()
    {
        yield return new WaitForSeconds(startWait);

        while (!gameOver)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;

                GameObject hazard = hazards[Random.Range(0, hazards.Length)];

                GameObject newHazard = Instantiate(hazard, spawnPosition, spawnRotation) as GameObject;
                activeHazards.Add(newHazard);
                yield return new WaitForSeconds(spawnWait);
            }

        }
            if (gameOver)
            {
                restartText.text = "Press 'R' for Restart";
                restart = true;

            }
        
        yield return new WaitForSeconds(waveWait);
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over";
        gameOver = true;
    }
}
