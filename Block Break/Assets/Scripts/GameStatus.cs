using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;

    [SerializeField] int scorePerBlockDestroyed = 5;

    [SerializeField] int currentScore = 0;
    [SerializeField] TextMeshProUGUI scoreText;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount> 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

   
    private void Start()
    {
        scoreText.text = currentScore.ToString();
       
    }
    void Update()
    {
        Time.timeScale = gameSpeed;   
    }

    public void AddToScore()
    {
        currentScore = currentScore + scorePerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }

    public void GameReset()
    {
        Destroy(gameObject);
    }

}
