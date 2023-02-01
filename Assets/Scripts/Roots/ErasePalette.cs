using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ErasePalette : MonoBehaviour {
    public Grid grid;
    public Tilemap tilemap;
    public TileBase brokenTile;

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            FunctionToGetRidOfTile();
        }
    }

    private void FunctionToGetRidOfTile() {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int position = grid.WorldToCell(mousePos * 10);


        tilemap.SetTile(position, AssignTile(tilemap.GetTile<Tile>(position)));
        tilemap.SetTile(new Vector3Int(position.x + 1, position.y - 1, position.z), AssignTile(tilemap.GetTile<Tile>(new Vector3Int(position.x + 1, position.y - 1, position.z))));
        tilemap.SetTile(new Vector3Int(position.x + 1, position.y + 1, position.z), AssignTile(tilemap.GetTile<Tile>(new Vector3Int(position.x + 1, position.y + 1, position.z))));
        tilemap.SetTile(new Vector3Int(position.x - 1, position.y - 1, position.z), AssignTile(tilemap.GetTile<Tile>(new Vector3Int(position.x - 1, position.y - 1, position.z))));
        tilemap.SetTile(new Vector3Int(position.x - 1, position.y + 1, position.z), AssignTile(tilemap.GetTile<Tile>(new Vector3Int(position.x - 1, position.y + 1, position.z))));
        tilemap.SetTile(new Vector3Int(position.x + 1, position.y, position.z), AssignTile(tilemap.GetTile<Tile>(new Vector3Int(position.x + 1, position.y, position.z))));
        tilemap.SetTile(new Vector3Int(position.x, position.y + 1, position.z), AssignTile(tilemap.GetTile<Tile>(new Vector3Int(position.x, position.y + 1, position.z))));
        tilemap.SetTile(new Vector3Int(position.x, position.y - 1, position.z), AssignTile(tilemap.GetTile<Tile>(new Vector3Int(position.x, position.y - 1, position.z))));
        tilemap.SetTile(new Vector3Int(position.x - 1, position.y, position.z), AssignTile(tilemap.GetTile<Tile>(new Vector3Int(position.x - 1, position.y, position.z))));

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
