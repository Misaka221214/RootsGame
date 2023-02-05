using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Trap : MonoBehaviour
{
    public GameObject DistroyBound1;
    public GameObject DistroyBound2;
    public GameObject GlobalTileMap;
    private TileManagement tilemap;
    private GridLayout gridLayout;

    private bool triggered = false;
    // Start is called before the first frame update
    void Start()
    {
        if (!GlobalTileMap)
        {
            GlobalTileMap = GameObject.FindGameObjectWithTag("TileMap");
        }
        tilemap = GlobalTileMap.GetComponent<TileManagement>();
        gridLayout = GlobalTileMap.GetComponentInParent<GridLayout>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!triggered && collision.gameObject.GetComponent<CanTriggerTrap>())
        {
            Vector3Int location1 = gridLayout.WorldToCell(DistroyBound1.transform.position);
            Vector3Int location2 = gridLayout.WorldToCell(DistroyBound2.transform.position);
            int xMin = Math.Min(location1.x, location2.x);
            int xMax = Math.Max(location1.x, location2.x);
            int yMin = Math.Min(location1.y, location2.y);
            int yMax = Math.Max(location1.y, location2.y);
            for (int i = xMin; i <= xMax; i++)
            {
                for (int j = yMin; j <= yMax; j++)
                {
                    tilemap.ForceRemoveTile(new Vector3Int(i,j, location1.z));
                }
            }

            triggered = true;
        }
    }
}
