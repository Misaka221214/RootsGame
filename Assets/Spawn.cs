using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Spawn : MonoBehaviour
{
    // Start is called before the first frame update
    private GameLoop _gameLoop;

    private GameObject GlobalTileMap;
    public bool isActive;
    public TileManagement tileManagement;
    private Tilemap tilemap;
    private GridLayout gridLayout;

    // Start is called before the first frame update
    void Start()
    {
        _gameLoop = FindObjectOfType<GameLoop>();
        tileManagement = GameObject.FindObjectOfType<TileManagement>();
        GlobalTileMap = GameObject.FindGameObjectWithTag("TileMap");
        tilemap = GlobalTileMap.GetComponent<Tilemap>();
        gridLayout = GlobalTileMap.GetComponentInParent<GridLayout>();
    }


    // Update is called once per frame
    void Update()
    {
        if(isActive) return;
        Vector3Int currLocation = gridLayout.WorldToCell(gameObject.transform.position);
        if (!tileManagement.isCovered(currLocation))
        {
            isActive = true;
        }
    }

}
