using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;
using Unity.VisualScripting;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;//https://medium.com/%40Code_With_K/understanding-the-singleton-pattern-in-c-and-unity-f5abd1ab80bb

    public TMP_Text timerText;
    public TMP_Text scoreText;
    public TMP_Text comboText;
    public TMP_Text finalScoreText;

    public GameObject restartButton;
    public GameObject gameOverPanel;
    public GameManager gameManager;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
           
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateTimer(float time)// Update the timer UI
    {
        if (timerText != null)
        {
            timerText.text = "Time: " + (int)Mathf.Ceil(time) + "s";//Display remaining time
        }
        
        
    }
    void Start()
    {
        // Hide the game over panel, restart button and final score.
        gameOverPanel.SetActive(false);
        restartButton.SetActive(false);
        finalScoreText.gameObject.SetActive(false);
        restartButton.GetComponent<Button>().onClick.AddListener(OnRestartButtonClicked);

    }




    public void UpdateScore(int score)
    {
        //Logic of score increase
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }

    public void UpdateCombo(int combo)
    {
        if (comboText != null)
            comboText.text = "+" + combo;// Update the combo count display
    }


    // Display the game over panel
    public void ShowGameOver()
    {//Display the game over panel, restart button and final score.
        gameOverPanel.SetActive(true);
        restartButton.SetActive(true);  
        finalScoreText.gameObject.SetActive(true);
        finalScoreText.text = "Final Score: " + (GameManager.Instance.Score+GameManager.Instance.Combo);
    }
    
    public void OnRestartButtonClicked()
    {
        // Clean UI
        gameOverPanel.SetActive(false);
        restartButton.SetActive(false);
        finalScoreText.gameObject.SetActive(false);

        //Score reset to zero
        UpdateScore(0);
        UpdateCombo(0);
        // Notify GameManager to restart the game
        gameManager.RestartGame();

    }
}