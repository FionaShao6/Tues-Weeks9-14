using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointerEvent : MonoBehaviour
{
    public Image image;
    public Sprite highLight;
    public Sprite normal;
    public GameObject prefab;
    public Vector2 spawnRange = new Vector2(5f, 5f);
    public void MouseIsOver()
    {
        image.sprite = highLight;

    }

    public void MouseNotOver()
    {
        image.sprite = normal;
    }

    public void MouseClicked()
    {
        //Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (prefab != null)
        {
            
            Vector2 randomPosition = new Vector2(
                Random.Range(-spawnRange.x, spawnRange.x),
                Random.Range(-spawnRange.y, spawnRange.y)
            );

            Instantiate(prefab, randomPosition, Quaternion.identity);
        }
    }
}
