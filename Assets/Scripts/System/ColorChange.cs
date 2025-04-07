using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ColorChange : MonoBehaviour
{
    public GameObject squarePrefab; // Ԥ����
    public Transform gridParent; // ������UI Panel ������壩
    public int gridSize = 2; // ��ʼ�����С
    public Image image;
      

    private GameObject oddSquare; // �洢������ɫ�ķ���
    private Color baseColor;
    private Color oddColor;

    public void GenerateGrid(int level)
    {
        // ������з���
        foreach (Transform child in gridParent)
        {
            Destroy(child.gameObject);
        }

        // ���������С
        gridSize = GetGridSize(level);
        List<GameObject> squares = new List<GameObject>();

        // ���ɻ�����ɫ
        baseColor = Random.ColorHSV(0, 1, 0.4f, 0.8f, 0.8f, 1);
        oddColor = GenerateCloseColor(baseColor, level); // ���ɽӽ�����ɫ

        // ���ɷ���
        for (int i = 0; i < gridSize * gridSize; i++)
        {
            GameObject newSquare = Instantiate(squarePrefab, gridParent);
            newSquare.GetComponent<Image>().color = baseColor;
            squares.Add(newSquare);
        }

        // ѡ��һ�������ɫ
        int oddIndex = Random.Range(0, squares.Count);
        oddSquare = squares[oddIndex];
        oddSquare.GetComponent<Image>().color = oddColor;
    }

    // �ؿ���Ӧ�����С
    private int GetGridSize(int level)
    {
        if (level == 1) return 2;
        if (level == 2) return 3;
        if (level >= 3 && level <= 5) return 3;
        if (level >= 6 && level <= 10) return 4;
        if (level >= 11 && level <= 15) return 5;
        return 6;
    }

    // ������ɫ�������ɫ�����Źؿ����ѣ�
    private Color GenerateCloseColor(Color baseColor, int level)
    {
        float offset = Mathf.Clamp(0.2f - (level * 0.005f), 0.02f, 0.2f); // ��ɫƫ�����
        return new Color(
            Mathf.Clamp01(baseColor.r + Random.Range(-offset, offset)),
            Mathf.Clamp01(baseColor.g + Random.Range(-offset, offset)),
            Mathf.Clamp01(baseColor.b + Random.Range(-offset, offset))
        );
    }
}
