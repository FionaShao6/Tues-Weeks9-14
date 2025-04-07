using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ColorChange : MonoBehaviour
{
    public GameObject squarePrefab; // 预制体
    public Transform gridParent; // 父对象（UI Panel 或空物体）
    public int gridSize = 2; // 初始网格大小
    public Image image;
      

    private GameObject oddSquare; // 存储特殊颜色的方块
    private Color baseColor;
    private Color oddColor;

    public void GenerateGrid(int level)
    {
        // 清空现有方块
        foreach (Transform child in gridParent)
        {
            Destroy(child.gameObject);
        }

        // 计算网格大小
        gridSize = GetGridSize(level);
        List<GameObject> squares = new List<GameObject>();

        // 生成基础颜色
        baseColor = Random.ColorHSV(0, 1, 0.4f, 0.8f, 0.8f, 1);
        oddColor = GenerateCloseColor(baseColor, level); // 生成接近的颜色

        // 生成方块
        for (int i = 0; i < gridSize * gridSize; i++)
        {
            GameObject newSquare = Instantiate(squarePrefab, gridParent);
            newSquare.GetComponent<Image>().color = baseColor;
            squares.Add(newSquare);
        }

        // 选择一个方块变色
        int oddIndex = Random.Range(0, squares.Count);
        oddSquare = squares[oddIndex];
        oddSquare.GetComponent<Image>().color = oddColor;
    }

    // 关卡对应网格大小
    private int GetGridSize(int level)
    {
        if (level == 1) return 2;
        if (level == 2) return 3;
        if (level >= 3 && level <= 5) return 3;
        if (level >= 6 && level <= 10) return 4;
        if (level >= 11 && level <= 15) return 5;
        return 6;
    }

    // 生成颜色相近的颜色（随着关卡变难）
    private Color GenerateCloseColor(Color baseColor, int level)
    {
        float offset = Mathf.Clamp(0.2f - (level * 0.005f), 0.02f, 0.2f); // 颜色偏差减少
        return new Color(
            Mathf.Clamp01(baseColor.r + Random.Range(-offset, offset)),
            Mathf.Clamp01(baseColor.g + Random.Range(-offset, offset)),
            Mathf.Clamp01(baseColor.b + Random.Range(-offset, offset))
        );
    }
}
