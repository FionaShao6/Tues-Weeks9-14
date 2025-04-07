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

    public BlockControler blockControler;
    public UIManager uiManager; // 拖拽引用！
    public BlockControler BlockControler; // 拖拽引用！
    public int Score;
    public int Combo;
    public float TimeLeft;
    bool isGameOver = false;
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
        OnCorrectAnswer.AddListener(AddScore);// Increase the score when the answer is correct
        OnWrongAnswer.AddListener(HandleWrongAnswer);// Handle error when wrong answer
        OnGameOver.AddListener(UIManager.Instance.ShowGameOver);// Display the end UI when the answer is wrong
        OnGameOver.AddListener(StopAllCoroutines);// Stop all coroutines when the game ends
    }
    
    public void StartNextLevel()
    {
        if (isGameOver) return;//If the game is over, no further action will be taken
        currentLevel++;

        blockControler.RegenerateGrid();  // Refresh the level, generate new blocks

    }

    IEnumerator GameTimer()
    {
        
        while (TimeLeft > 0 && !isGameOver)
        {
            TimeLeft -= Time.deltaTime;//Reduce time per frame
            if (UIManager.Instance != null)
            {
                UIManager.Instance.UpdateTimer(TimeLeft);// Update the timer on the UI
            }
            yield return null;
        }
        if (!isGameOver) {
            OnGameOver.Invoke();// Trigger the game end event when the time is up
        }
            
    }

    

    void AddScore()
    {
        Score++;

        if (Score % 5 == 0)//If the score is 5n, which is a multiple of 5, then the combo is that n.
        {

            Combo = Score / 5;
        }

        if (UIManager.Instance != null)
        {//Refresh the UI
            UIManager.Instance.UpdateScore(Score);
            UIManager.Instance.UpdateCombo(Combo);
        }
    }
    
    public void HandleWrongAnswer()
    {
        if (!isGameOver)
        {
            isGameOver = true;  // When the answer is wrong, the game end is true
            StopAllCoroutines();  // Stop all coroutines
            OnGameOver.Invoke();  // Call the game end event
        }

        if (UIManager.Instance != null)
        {
            UIManager.Instance.ShowGameOver();  // Display the game over screen
        }
        for (int i = 0; i < blockControler.gridParent.childCount; i++)
        {//Traverse all blocks and disable their buttons to prevent clicks
            Transform child = blockControler.gridParent.GetChild(i);
            Button button = child.GetComponent<Button>();
            if (button != null)
            {
                button.interactable = false;  // Disable all buttons
            }
        }
    }

    public void RestartGame()
    {
        SetupGame(); // Reinitialize the game
        blockControler.RegenerateGrid(); // Reinitialize the blocks
        isGameOver = false; // Reset game over flag
        TimeLeft = 60f; // Reset the timer
        StartCoroutine(GameTimer()); // Restart the countdown timer
    }
}



