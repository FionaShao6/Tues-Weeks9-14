using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    private bool isTarget;  
    private Image image;

    void Start()
    {
        image = GetComponent<Image>();
        
    }

   
    public void Initialize(bool isTargetBlock, Color blockColor)
    {

        GetComponent<Button>().onClick.RemoveAllListeners(); //  Clear the old monitoring first
        isTarget = isTargetBlock;  // Set target state
        if (image == null)
            image = GetComponent<Image>();

        image.color = blockColor;  // set color

        // add click event
        GetComponent<Button>().onClick.AddListener(HandleClick);
        
    }

    
    void HandleClick()
    {
        
        if (isTarget)
        {

            GameManager.Instance.OnCorrectAnswer.Invoke();// right answer

        }
        else
        {

            GameManager.Instance.OnWrongAnswer.Invoke();    // wrong answer
        }
    }
}