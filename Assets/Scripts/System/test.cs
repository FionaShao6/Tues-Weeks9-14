using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    private bool isTarget;  
    private Image image;

    void Start()
    {
        image = GetComponent<Image>();

        //Get the Button component and add a click event to the button
        
        //image.AddListener(HandleClick);  // 
    }

    
    public void Initialize(bool isTargetBlock, Color blockColor)
    {
        isTarget = isTargetBlock;  
        if (image == null)
            image = GetComponent<Image>();

        image.color = blockColor;  
    }

    
    void HandleClick()
    {
        
        if (isTarget)
        {

            GameManager.Instance.StartNextLevel();// right answer

        }
        else
        {

            GameManager.Instance.StopAllCoroutines();  // wrong answer
        }
    }
}