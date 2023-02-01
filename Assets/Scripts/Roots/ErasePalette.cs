using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ErasePalette : MonoBehaviour {
    public Grid grid;
    public Tilemap tilemap;

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            FunctionToGetRidOfTile();
        }
    }

    void FunctionToGetRidOfTile() {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int position = grid.WorldToCell(mousePos * 10);
        tilemap.SetTile(position, null);
        Debug.Log(mousePos);
        Debug.Log(position);
    }
}
