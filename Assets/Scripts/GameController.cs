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

    [Header("Score Components")]
    [SerializeField] private TextMeshProUGUI scoreText;
    private float sliderCurrentFillAmount = 1f;
    private int playerScore;

    [Header("Game Over Components")]
    [SerializeField] private GameObject gameOverScreen;

    [Header("High Score Components")]
    [SerializeField] private TextMeshProUGUI highScoreText;

    [Header("Gameplay Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] audioClips;

    public static GameState currentGameStatus;

    private void Awake() 
    {
        currentGameStatus = GameState.Waiting;

        InitHighScore();
    }

    private void InitHighScore()
    {
        if(PlayerPrefs.HasKey(Constants.HIGH_SCORE))
        {
            highScoreText.text = PlayerPrefs.GetInt(Constants.HIGH_SCORE).ToString();
        }
        else
        {
            PlayerPrefs.SetInt(Constants.HIGH_SCORE, 0);
        }
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

        if(sliderCurrentFillAmount <= 0)
        {
            GameOver();
        }
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

        PlayMusic(1);
    }

    private void GameOver()
    {
        currentGameStatus = GameState.GameOver;

        PlayMusic(2, false);

        //show gameover screen
        gameOverScreen.SetActive(true);

        SetHighScore();
    }

    private void SetHighScore()
    {
        if(PlayerPrefs.HasKey(Constants.HIGH_SCORE) && playerScore > PlayerPrefs.GetInt(Constants.HIGH_SCORE))
        {
            PlayerPrefs.SetInt(Constants.HIGH_SCORE, playerScore);
            highScoreText.text = playerScore.ToString();
        }
    }

    public void ResetGame()
    {
        currentGameStatus = GameState.Waiting;

        PlayMusic(0);

        //put timer to 1
        sliderCurrentFillAmount = 1f;
        timerImage.fillAmount = 1f;

        //reset score
        playerScore = 0;
        scoreText.text = "0";
    }

    private void PlayMusic(int index, bool isLoop = true)
    {
        audioSource.clip = audioClips[index];
        audioSource.Play();
        audioSource.loop = isLoop;
    }
}
