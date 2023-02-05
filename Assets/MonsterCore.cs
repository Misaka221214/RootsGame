using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MonsterCore : MonoBehaviour
{
    public CreatureType type;

    private GameLoop _gameLoop;
    public float Interval = .5f;
    
    private GameObject GlobalTileMap;
    public bool isActive;
    private Tilemap tilemap;
    private GridLayout gridLayout;
    public TileManagement tileManagement;

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
        // Only trigger once
        if(isActive) return;
        Vector3Int currLocation = gridLayout.WorldToCell(gameObject.transform.position);
        if (!tileManagement.isCovered(currLocation))
        {
            isActive = true;
            StartCoroutine(SpawnPeople());
        }
    }

    IEnumerator SpawnPeople()
    {
        while (true)
        {
            if (_gameLoop.state == GameLoopState.Underground)
            {
                Instantiate(CreatureData.CreatureEnemyObject[type], gameObject.transform.position,
                    gameObject.transform.rotation);
            }
            yield return new WaitForSeconds(Interval);
        }
    }
}
