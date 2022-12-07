using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public Text scoreText, timeText;
    public float startTime = 10.0f;
    public GameObject gameOverText, finishText;

    private float currentTime;
    private int scoreCounter, timeCounter;

    void Start()
    {
        currentTime = startTime;
        gameOverText.SetActive(false);
        finishText.SetActive(false);
    }

    void Update()
    {
        //Reducimos currentTime
        currentTime -= Time.deltaTime;
        timeCounter = (int)currentTime;

        //Cuando el tiempo es menor o igual a 0, game over
        if(currentTime <= 0.0f)
        {
            //Para no ver tiempo negativo
            timeCounter = 0;

            gameOverText.SetActive(true);

        }

        //Actualizamos la interfaz

        scoreText.text = "Score: " + scoreCounter;
        timeText.text = "Time: " + timeCounter;
    }

    public void IncreaseScore(int points)
    {
        scoreCounter += points;
    }

    public void GameFinish()
    {
        finishText.SetActive(true);
    }
}
