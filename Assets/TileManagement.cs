using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManagement : MonoBehaviour
{
    private Grid grid;
    private Tilemap tilemap;
    private Dictionary<Vector3Int, TileInfo> tileInfoMap = new Dictionary<Vector3Int,TileInfo>();

    // Start is called before the first frame update
    void Start()
    {
        tilemap = GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UserHitTile(Vector3Int pos)
    {
        TileBase tb = tilemap.GetTile<Tile>(pos);
        if (!tb)
        {
            return;
        } 
        if (tb.name == "EmptyHole")
        {
            RevealEmptyHole(pos);
        }
        else
        {
            TileInfo tileInfo = TryBeakTile(pos);
            if (tileInfo.maxHealth == 0)
            {
                return;
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
    
    public void ForceRemoveTile(Vector3Int pos)
    {
        TileBase tb = tilemap.GetTile<Tile>(pos);
        if (!tb)
        {
            return;
        } 
        if (tb.name == "EmptyHole")
        {
            RevealEmptyHole(pos);
        }
        else
        {
            if (tileInfoMap.ContainsKey(pos))
            {
                tileInfoMap.Remove(pos);
            }
            tilemap.SetTile(pos, null);

        }
    }
    
    private TileInfo TryBeakTile(Vector3Int pos)
    {
        // if(tb == null) {
        //     return null;
        // }

        if (!tileInfoMap.ContainsKey(pos))
        {
            TileBase tb = tilemap.GetTile<Tile>(new Vector3Int(pos.x, pos.y, pos.z));
            if (tb == null)
            {
                TileInfo tileInfo;
                tileInfo.maxHealth = 0;
                tileInfo.currHealth = 0;
                return tileInfo;
            }
            tileInfoMap[pos] = getTileStiffness(tb);
        }

        TileInfo currTileInfo = tileInfoMap[pos];
        currTileInfo.currHealth -= 1;
        if (currTileInfo.currHealth == 0)
        {
            tileInfoMap.Remove(pos);
            return currTileInfo;
        }
        else
        {
            tileInfoMap[pos] = currTileInfo;
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
    
    private void RevealEmptyHole(Vector3Int position)
    {
        int x = position.x;
        int y = position.y;
        Stack<int> xStack = new Stack<int>();
        Stack<int> yStack = new Stack<int>();
        xStack.Push(x);
        yStack.Push(y);
        while (xStack.Count != 0)
        {
            x = xStack.Pop();
            y = yStack.Pop();
            TileBase tb = tilemap.GetTile<Tile>(new Vector3Int(x, y, position.z));
            if (tb && tb.name =="EmptyHole")
            {
                tilemap.SetTile(new Vector3Int(x, y, position.z), null);
                xStack.Push(x-1);
                yStack.Push(y);
                xStack.Push(x+1);
                yStack.Push(y);
                xStack.Push(x);
                yStack.Push(y+1);
                xStack.Push(x);
                yStack.Push(y-1);
            }
        }
    }
}
