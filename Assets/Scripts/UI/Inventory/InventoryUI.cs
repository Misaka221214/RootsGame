using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public List<InventorySlot> slots;
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

    private void Awake()
    {

    }

    void Start()
    {
        // TODO: Should InventoryManager be a Singleton?
        // inventoryManager = FindObjectOfType<InventoryManager>();

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
        inventoryManager.AddInventory(CreatureType.SLIME);
        inventoryManager.AddInventory(CreatureType.SLIME);
        inventoryManager.AddInventory(CreatureType.RABBIT);
# endif

        UpdateDisplay();
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
            } else
            {
                slots[i].HideDisplay();
            }
        }

    }
}
