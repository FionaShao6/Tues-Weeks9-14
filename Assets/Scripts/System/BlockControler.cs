using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Collections.AllocatorManager;
using UnityEngine.UI;

public class BlockControler : MonoBehaviour
{
    //public static BlockControler Instance;
    public GameManager gameManager;
    public BlockControler blockControler;
    public GameObject blockPrefab; // prefab
    public Transform gridParent;   // 
    public float delta = 0.3f;
    public Color baseColor;
    public Color targetColor;

    //void Awake()
    //{
    //    if (Instance == null)
    //    {
    //        Instance = this;
           
    //    }
    //    else
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    void Start()
    {
        

        if (blockPrefab == null || gridParent == null)
        {
          
            return;
        }
        GenerateGrid(16, 1);
    }

    public void RegenerateGrid()
    {
       
        foreach (Transform child in gridParent)
        {
            Destroy(child.gameObject);
        }
        GenerateGrid(16, 1);
    }
    public void DisableAllButtons()
    {
        for (int i = 0; i < gridParent.childCount; i++)
        {
            Transform child = gridParent.GetChild(i);
            Button button = child.GetComponent<Button>();
            if (button != null)
            {
                button.interactable = false;
            }
        }
    }
    void GenerateGrid(int totalBlocks, int targetCount)
    {
       
        // Randomly generate basic colors
        baseColor = Random.ColorHSV(0, 1, 0.4f, 0.8f, 0.8f, 1);
        // The target block color is slightly different from the base color
        targetColor = new Color(
            Mathf.Clamp01(baseColor.r + delta),
            Mathf.Clamp01(baseColor.g + delta),
            Mathf.Clamp01(baseColor.b + delta),
            baseColor.a
        );
        //
        int targetIndex = Random.Range(0, totalBlocks);

        for (int i = 0; i < totalBlocks; i++)
        {
            bool isTarget = (i == targetIndex);
            Color c;//c is a color variable
            if (isTarget == true)
            {
                c = targetColor;  
            }
            else
            {
                c = baseColor;    
            }

            GameObject block = Instantiate(blockPrefab, gridParent);
            block.GetComponent<Block>().Initialize(isTarget, c);  
        }
    }

}