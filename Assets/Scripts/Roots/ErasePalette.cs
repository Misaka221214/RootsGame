using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

struct TileInfo
{
    public int maxHealth;
    public int currHealth;
}
public class ErasePalette : MonoBehaviour {
    public Grid grid;
    public TileManagement tilemap;
    public TileBase brokenTile;
    public int range = 5;
    void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            FunctionToGetRidOfTile();
        }
    }

    private void FunctionToGetRidOfTile() {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int position = grid.WorldToCell(mousePos * 10);
        for (int i = -range; i <= range; i++)
        {
            for (int j = -range; j <= range; j++)
            {
                if (i * i + j * j < range * range)
                {
                    Vector3Int pos = new Vector3Int(position.x + i, position.y + j, position.z);
                    tilemap.UserHitTile(pos);
                }
            }
        }
    }
}
