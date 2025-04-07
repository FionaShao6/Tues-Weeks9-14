using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TMP_Text timerText;
    public TMP_Text scoreText;
    public TMP_Text comboText;
    public GameObject gameOverPanel;
    public TMP_Text finalScoreText;
    public GameObject restartButton;


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

    public void UpdateTimer(float time)
    {
        if (timerText != null)
        {
            timerText.text = "Time: " + (int)Mathf.Ceil(time) + "s";
        }
        
        
    }
    void Start()
    {
        // Hide the game over panel and restart button
        gameOverPanel.SetActive(false);
        restartButton.SetActive(false);
        finalScoreText.gameObject.SetActive(false);
        restartButton.GetComponent<Button>().onClick.AddListener(OnRestartButtonClicked);

    }

    public void UpdateScore(int score)
    {

        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }

    public void UpdateCombo(int combo)
    {
        if (comboText != null)
            comboText.text = "+" + combo;
    }

   

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        restartButton.SetActive(true);  
        finalScoreText.gameObject.SetActive(true);
        finalScoreText.text = "Final Score: " + (GameManager.Instance.Score+GameManager.Instance.Combo);
    }
    public void OnRestartButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        gameOverPanel.SetActive(false);
        restartButton.SetActive(false);
        finalScoreText.gameObject.SetActive(false);
        
        UpdateScore(0);
        UpdateCombo(0);
    }
}