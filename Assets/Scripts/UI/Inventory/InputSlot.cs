using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputSlot : MonoBehaviour
{
    public RemoveInputBtn removeBtn;
    public Image contentImg;

    public CreatureType creature;

    public bool isEmpty;

    private CraftSystem craftSystem;
    private InventoryManager inventoryManager;
    private InventoryUI InventoryUI;

    private void Awake()
    {
        ClearSlot();

        craftSystem = FindObjectOfType<CraftSystem>();
        inventoryManager = FindObjectOfType<InventoryManager>();
        InventoryUI = FindObjectOfType<InventoryUI>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateDisplay(CreatureType creature)
    {
        this.creature = creature;
        isEmpty = false;

        Sprite creatureSprite = CreatureData.CreatureSprite[creature];
        contentImg.sprite = creatureSprite;
        contentImg.gameObject.SetActive(true);
        removeBtn.gameObject.SetActive(true);
    }

    public void ClearSlot()
    {
        isEmpty = true;

        contentImg.gameObject.SetActive(false);
        removeBtn.gameObject.SetActive(false);
    }

    public void RemoveFromInput()
    {
        if (!isEmpty && craftSystem.RemoveInput(creature))
        {
            inventoryManager.AddInventory(creature);
            InventoryUI.UpdateDisplay();

            craftSystem.UpdateInputDisplay();
        }
    }
}
