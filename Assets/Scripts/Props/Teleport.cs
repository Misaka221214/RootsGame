using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Teleport : MonoBehaviour
{
    public GameObject GlobalTileMap;
    public bool isActive;
    private Tilemap tilemap;
    private GridLayout gridLayout;

    public GameObject target;

    private Teleport otherTeleport;

    public float CD_in_ms = 1000;
    private float _lastTeleport = -2000;
    
    // Start is called before the first frame update
    void Start()
    {
        if (!GlobalTileMap)
        {
            GlobalTileMap = GameObject.FindGameObjectWithTag("TileMap");
        }
        tilemap = GlobalTileMap.GetComponent<Tilemap>();
        gridLayout = GlobalTileMap.GetComponentInParent<GridLayout>();
        otherTeleport = target.GetComponent<Teleport>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3Int currLocation = gridLayout.WorldToCell(gameObject.transform.position);
        if (tilemap.GetTile<Tile>(currLocation) == null)
        {
            isActive = true;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        float now = Time.time * 1000;
        if (otherTeleport.isActive && collision.gameObject.GetComponent<Teleportable>()
            &&  now - _lastTeleport > CD_in_ms
            )
        {
            _lastTeleport = now;
            otherTeleport.SetTime(now);
            collision.gameObject.transform.position = target.transform.position;
        }
    }

    public void SetTime(float time)
    {
        _lastTeleport = time;
    }
    
    
}
