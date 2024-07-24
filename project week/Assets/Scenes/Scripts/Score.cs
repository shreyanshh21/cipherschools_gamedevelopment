using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;
    public Text highscoreText;

    int currentScore;
    int highscore;

    public void Start()
    {
        // Load highscore from PlayerPrefs
        highscore = PlayerPrefs.GetInt("highscore", 0);
        highscoreText.text = highscore.ToString();
    }

    private void Update()
    {
        if (player != null)  // Ensure player reference is not null
        {
            currentScore = Mathf.FloorToInt(player.position.z);
            scoreText.text = currentScore.ToString();

            if (currentScore > highscore)
            {
                highscore = currentScore;
                highscoreText.text = highscore.ToString();
                PlayerPrefs.SetInt("highscore", currentScore);
            }
        }
        else
        {
            Debug.LogWarning("Player reference is not assigned in Score script!");
        }
    }
}
