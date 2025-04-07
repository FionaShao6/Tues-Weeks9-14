using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    
    public UnityEvent OnCorrectAnswer;
    public UnityEvent OnWrongAnswer;
    public UnityEvent OnGameOver;
    

    public int Score;
    public int Combo;
    public float TimeLeft;
    
    public int currentLevel = 1;
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

    void Start()
    {
        SetupGame();
        StartCoroutine(GameTimer());  // Start countdown coroutine
        //OnCorrectAnswer.AddListener(StartNextLevel);
        


    }

    void SetupGame()
    {
        Score = 0;
        Combo = 0;
        TimeLeft = 60f;


        // Adding Listener
        OnCorrectAnswer.AddListener(AddScore);
        OnGameOver.AddListener(StopAllCoroutines);
        //OnCorrectAnswer.AddListener(StartNextLevel);
        OnWrongAnswer.AddListener(HandleWrongAnswer);
        OnGameOver.AddListener(UIManager.Instance.ShowGameOver);

    }
    
    public void StartNextLevel()
    {
        
        currentLevel++; 
       
        BlockControler.Instance.RegenerateGrid(); // Refresh the level, generate new blocks

    }

    IEnumerator GameTimer()
    {
        
        while (TimeLeft > 0)
        {
            TimeLeft -= Time.deltaTime;
            if (UIManager.Instance != null)
            {
                UIManager.Instance.UpdateTimer(TimeLeft);
            }
            yield return null;
        }
        OnGameOver.Invoke();
    }

    

    void AddScore()
    {
        Score++;

        if (Score % 5 == 0)
        {

            Combo = Score / 5;
        }

        if (UIManager.Instance != null)
        {
            UIManager.Instance.UpdateScore(Score);
            UIManager.Instance.UpdateCombo(Combo);
        }
    }
    
    public void HandleWrongAnswer()
    {
        StopAllCoroutines();
        if (UIManager.Instance != null)
        {
            UIManager.Instance.ShowGameOver();  // Display the game over screen
        }
        for (int i = 0; i < BlockControler.Instance.gridParent.childCount; i++)
        {
            Transform child = BlockControler.Instance.gridParent.GetChild(i);
            Button button = child.GetComponent<Button>();
            if (button != null)
            {
                button.interactable = false;  // Disable all buttons
            }
        }
    }

    public void RestartGame()
    {
        
        SetupGame();
    }
}



