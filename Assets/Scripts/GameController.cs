using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private Image timerImage;
    [SerializeField] private float gameTime;
    [SerializeField] private TextMeshProUGUI scoreText;

    private float sliderCurrentFillAmount = 1f;
    private int playerScore;

    private void Update() 
    {
        AdjustTimer();
    }

    private void AdjustTimer()
    {
        timerImage.fillAmount = sliderCurrentFillAmount - Time.deltaTime / gameTime;

        sliderCurrentFillAmount = timerImage.fillAmount;
    }

    public void UpdatePlayerScore(int asteroidHitPoints)
    {
        playerScore += asteroidHitPoints;
        scoreText.text = playerScore.ToString();
    }
}
