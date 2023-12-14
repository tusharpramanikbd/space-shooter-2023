using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum GameState
{
    Waiting,
    playing,
    GameOver
}

public class GameController : MonoBehaviour
{
    [SerializeField] private Image timerImage;
    [SerializeField] private float gameTime;
    [SerializeField] private TextMeshProUGUI scoreText;

    private float sliderCurrentFillAmount = 1f;
    private int playerScore;

    public static GameState currentGameStatus;

    private void Awake() 
    {
        currentGameStatus = GameState.Waiting;
    }

    private void Update() 
    {
        if(currentGameStatus == GameState.playing)
        {
            AdjustTimer();
        }
    }

    private void AdjustTimer()
    {
        timerImage.fillAmount = sliderCurrentFillAmount - Time.deltaTime / gameTime;

        sliderCurrentFillAmount = timerImage.fillAmount;
    }

    public void UpdatePlayerScore(int asteroidHitPoints)
    {
        if(currentGameStatus != GameState.playing) return;

        playerScore += asteroidHitPoints;
        scoreText.text = playerScore.ToString();
    }

    public void StartGame()
    {
        currentGameStatus = GameState.playing;
    }
}
