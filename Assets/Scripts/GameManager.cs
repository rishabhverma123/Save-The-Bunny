using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //so that we can directly access this script from other script
    bool gameOver = false;
    private int score = 0;
    public Text scoreText;
    public GameObject gamePanel;
    public Text gameOverScoreText;
    // Start is called before the first frame update

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    
    public void GameOver()
    {
        gameOver = true;

        /**
         * when enemy collide with player we have to Game Over
         * For game over we have to stop spawning enemy (whose code is already present in EnemySpawnerScript)
         * TO call StopSpawning() from EnemySpawnerScript first get access to gameobject with which that script is attached
         * then get access to its componenet with name EnemySpawnerScript then call its StopSpawning function
         * */
        GameObject.Find("EnemySpawner").GetComponent<EnemySpawnerScript>().StopSpawning();
        gameOverScoreText.text = "Score :" + score;
        gamePanel.SetActive(true);
    }
    public void IncrementScore()
    {
        if (!gameOver)
        {
            score++;
            scoreText.text = score.ToString();
            
            print(score);
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
}
