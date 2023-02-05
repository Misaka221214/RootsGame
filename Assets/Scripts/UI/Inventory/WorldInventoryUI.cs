using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WorldInventoryUI : MonoBehaviour
{
    public Vector3 defaultSpawnPosition;
    public List<WorldInventorySlot> slots;
    private InventoryManager inventoryManager;

    private void OnEnable()
    {
        EventManager.OnInventoryUpdated += UpdateDisplay;

        UpdateDisplay();
    }

    private void OnDisable()
    {
        EventManager.OnInventoryUpdated -= UpdateDisplay;
    }

    void Start()
    {        
        // TestOnly_SetUp();
        UpdateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TestOnly_SetUp()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();

#if UNITY_EDITOR
        inventoryManager.AddInventory(CreatureType.NEYMAR);
        inventoryManager.AddInventory(CreatureType.NEYMAR);
        inventoryManager.AddInventory(CreatureType.NEYMAR);
        inventoryManager.AddInventory(CreatureType.NEYMAR);
        inventoryManager.AddInventory(CreatureType.NEYMAR);
        inventoryManager.AddInventory(CreatureType.NEYMAR);
        inventoryManager.AddInventory(CreatureType.NEYMAR);
        inventoryManager.AddInventory(CreatureType.NEYMAR);
        inventoryManager.AddInventory(CreatureType.NEYMAR);
        inventoryManager.AddInventory(CreatureType.NEYMAR);
        inventoryManager.AddInventory(CreatureType.SLIME);
        inventoryManager.AddInventory(CreatureType.SLIME);
        inventoryManager.AddInventory(CreatureType.RABBIT);
# endif
    }

    public void UpdateDisplay()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();

        for (int i = 0; i < slots.Count; i++)
        {
            if (i < inventoryManager.creatureToQuantity.Count)
            {
                CreatureType type = inventoryManager.creatureToQuantity.ElementAt(i).Key;
                int val = inventoryManager.creatureToQuantity[type];
                slots[i].UpdateDisplay(type, val);
            }
            else
            {
                slots[i].HideDisplay();
            }
        }

    }

    public void SpawnCreature(CreatureType creature)
    {
        // TODO: May need to update spawn location
        Debug.Log("Spawn Creature at default world position");

        if (CreatureData.PlayerCreaturePrefabs.ContainsKey(creature))
        {
            Vector3 camPosition = GameObject.FindGameObjectWithTag("MainCamera").transform.position;
            Spawn[] spawns = GameObject.FindObjectsOfType<Spawn>();
            float closet = Single.PositiveInfinity;
            Spawn closetSpawn = null;
            foreach (var spawn in spawns)
            {
                float dist = (camPosition - spawn.transform.position).magnitude;
                if (dist < closet && spawn.isActive)
                {
                    closet = dist;
                    closetSpawn = spawn;
                }
            }
            if(!closetSpawn) return;
            GameObject go = Instantiate(CreatureData.PlayerCreaturePrefabs[creature],
                closetSpawn.transform.position, Quaternion.identity);
            inventoryManager.RemoveCreature(creature);
        }
        else
        {
            Debug.LogError("Cannot find creature prefab");
        }

        UpdateDisplay();
    }
}
