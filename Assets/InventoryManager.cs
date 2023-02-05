using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct InventoryItem
{
    public InventoryItem(CreatureType t)
    {
        type = t;
        name = CreatureData.CreatureName[t];
        avatar = CreatureData.CreatureSprite[t];

    }
    public Sprite avatar;
    public String name;
    public CreatureType type;
}
public class InventoryManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<InventoryItem> allitems = new List<InventoryItem>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddInventory(CreatureType type)
    {
        allitems.Add(new InventoryItem(type));
        Debug.Log(allitems.Count);
    }
}
