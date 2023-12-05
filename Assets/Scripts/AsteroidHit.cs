using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AsteroidHit : MonoBehaviour
{
    [SerializeField] private GameObject asteroidExplosion;
    [SerializeField] private int baseScore = 10;
    [SerializeField] private GameObject popupCanvas;

    private GameController gameController;

    private void Awake() 
    {
        gameController = FindObjectOfType<GameController>();

        if(gameController == null)
        {
            Debug.LogError("Could not find GameController inside AsteroidHit");
        }
    }

    public void AsteroidDestroy()
    {
        Instantiate(asteroidExplosion, transform.position, transform.rotation);

        CalculateScore();

        //destroy astreroid itself
        Destroy(this.gameObject);
    }

    private void CalculateScore()
    {
        int asteroidScore = baseScore * (int)GetAsteroidDistance();

        InitPopupCanvas(asteroidScore);

        gameController.UpdatePlayerScore(asteroidScore);
    }

    private float GetAsteroidDistance()
    {
        Transform playerTransform = GameObject.FindGameObjectWithTag(Constants.PLAYER_TAG).transform;

        return Vector3.Distance(transform.position, playerTransform.position);
    }

    private void InitPopupCanvas(int asteroidScore)
    {
        popupCanvas.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = asteroidScore.ToString();
        Instantiate(popupCanvas, transform.position, Quaternion.identity);
    }
}
