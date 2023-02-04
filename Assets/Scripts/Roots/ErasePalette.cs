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
    public Tilemap tilemap;
    public TileBase brokenTile;
    private Dictionary<int, Dictionary<int, TileInfo>> tileInfoMap = new Dictionary<int, Dictionary<int,TileInfo>>();
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
                    TileInfo tileInfo = TryBeakTile(position.x + i, position.y + j, position.z);
                    Vector3Int pos = new Vector3Int(position.x + i, position.y + j, position.z);
                    if (tileInfo.maxHealth == 0)
                    {
                        continue;
                    }
                    if (tileInfo.currHealth == 0)
                    {
                        tilemap.SetTile(pos, null);
                    }
                    else
                    {
                        Color c = tilemap.GetColor(pos);
                        c.a = (tileInfo.currHealth * 1f) / tileInfo.maxHealth;
                        // Disable color lock
                        tilemap.SetTileFlags(pos, TileFlags.None);
                        tilemap.SetColor(pos, c);
                    }
                }
            }
        }
    }

    private TileInfo TryBeakTile(int x, int y, int z)
    {
        // if(tb == null) {
        //     return null;
        // }

        if (!tileInfoMap.ContainsKey(x))
        {
            tileInfoMap[x] = new Dictionary<int, TileInfo>();
        }
        if (!tileInfoMap[x].ContainsKey(y))
        {
            TileBase tb = tilemap.GetTile<Tile>(new Vector3Int(x, y, z));
            if (tb == null)
            {
                TileInfo tileInfo;
                tileInfo.maxHealth = 0;
                tileInfo.currHealth = 0;
                return tileInfo;
            }
            tileInfoMap[x][y] = getTileStiffness(tb);
        }

        TileInfo currTileInfo = tileInfoMap[x][y];
        currTileInfo.currHealth -= 1;
        if (currTileInfo.currHealth == 0)
        {
            tileInfoMap[x].Remove(y);
            return currTileInfo;
        }
        else
        {
            tileInfoMap[x][y] = currTileInfo;
        }

        return currTileInfo;
    }

    private TileInfo getTileStiffness(TileBase tb)
    {
        TileInfo info;
        switch (tb.name) {
            case "Hardrock":
                info.maxHealth = 5;
                info.currHealth = 5;
                return info;
            default:
                info.maxHealth = 3;
                info.currHealth = 3;
                return info;
        }
    }
}
