using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public List<InventorySlot> slots;
    private InventoryManager inventoryManager;

    private void Awake()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
    }

    void Start()
    {
        TestOnly_SetUp();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TestOnly_SetUp()
    {
        inventoryManager.AddInventory(CreatureType.NEYMAR);
        inventoryManager.AddInventory(CreatureType.NEYMAR);
        inventoryManager.AddInventory(CreatureType.NEYMAR);
        inventoryManager.AddInventory(CreatureType.SLIME);
        inventoryManager.AddInventory(CreatureType.SLIME);
        inventoryManager.AddInventory(CreatureType.RABBIT);

        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (i < inventoryManager.creatureToQuantity.Count)
            {
                CreatureType type = inventoryManager.creatureToQuantity.ElementAt(i).Key;
                int val = inventoryManager.creatureToQuantity[type];
                slots[i].UpdateDisplay(type, val);
            } else
            {
                slots[i].HideDisplay();
            }
        }

    }
}
