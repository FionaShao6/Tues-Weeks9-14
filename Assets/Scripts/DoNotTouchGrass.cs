using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DoNotTouchGrass : MonoBehaviour
{
    public Tilemap tilemap;
    public Tile grass;
    public Tile stone;
    public Tile flower;
    float speed = 5f;
    bool isMoving = false;
    int time = 0;
    Vector3 targetPosition;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPos = tilemap.WorldToCell(mousePos);
            targetPosition = tilemap.CellToWorld(gridPos);

            if (tilemap.GetTile(gridPos)==stone|| tilemap.GetTile(gridPos) == grass)
            {
                
              
                isMoving = true;
                Debug.Log(gridPos);
            }
            else
            {
                isMoving = false;
            }
            
        }
        if(isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            if(Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                isMoving = false;
            }
        }
    }
}
