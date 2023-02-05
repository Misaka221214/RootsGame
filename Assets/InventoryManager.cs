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
    public List<InventoryItem> allitems = new List<InventoryItem>();
    public Dictionary<CreatureType, int> creatureToQuantity = new();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddInventory(CreatureType type)
    {
        var newItem = new InventoryItem(type);

        allitems.Add(newItem);
        Debug.Log(allitems.Count);

        if (creatureToQuantity.ContainsKey(type))
        {
            creatureToQuantity[type]++;
        } else
        {
            creatureToQuantity.Add(type, 1);
        }
    }
}
