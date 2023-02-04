using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ErasePalette : MonoBehaviour {
    public Grid grid;
    public Tilemap tilemap;
    public TileBase brokenTile;
    private bool mouseDown = false;
    void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            mouseDown = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            mouseDown = false;
        }

        if (mouseDown)
        {
            FunctionToGetRidOfTile();
        }

    }

    private void FunctionToGetRidOfTile() {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int position = grid.WorldToCell(mousePos * 10);
        for (int i = -2; i <= 2; i++)
        {
            for (int j = -2; j <= 2; j++)
            {
                tilemap.SetTile(new Vector3Int(position.x + i, position.y - j, position.z), AssignTile(tilemap.GetTile<Tile>(new Vector3Int(position.x + i, position.y - j, position.z))));
            }
        }
    }

    private TileBase AssignTile(TileBase tb) {
        if(tb == null) {
            return null;
        }
        switch (tb.name) {
            case "Hardrock":
                return brokenTile;
            default:
                return null;
        }
    }
}
