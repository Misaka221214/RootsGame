using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftSystem : MonoBehaviour
{
    public List<InputSlot> inputslots;
    public OutputSlot outputSlot;

    private List<KeyValuePair<List<CreatureType>, CreatureType>> recipes = new();
    private List<CreatureType> inputList = new();
    private InventoryManager inventoryManager;
    private InventoryUI inventoryUI;

    private void Awake()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
        inventoryUI = FindObjectOfType<InventoryUI>();
    }

    void Start()
    {
        InitRecipes();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitRecipes() {
        // TODO: Add all recipes

        recipes.Add(new KeyValuePair<List<CreatureType>, CreatureType>(
            new List<CreatureType>() { CreatureType.NEYMAR, CreatureType.SLIME }, CreatureType.SLIME_NEYMAR));
    }

    public void OnCraft()
    {
        if (inputList.Count == 2)
        {
            var output = GetRecipeOutput();
            if (output == CreatureType.TRASH)
            {
                // TODO
            } else
            {
                outputSlot.ShowOutput(output);
                inventoryManager.AddInventory(output);
                inventoryUI.UpdateDisplay();
                inputList.Clear();
                UpdateInputDisplay();
            }
        }
    }

    public CreatureType GetRecipeOutput()
    {
        var result = CreatureType.TRASH;

        foreach (var recipe in recipes)
        {
            if (recipe.Key.Contains(inputList[0]) && recipe.Key.Contains(inputList[1]))
            {
                result = recipe.Value;
            }
        }

        return result;
    } 

    public bool AddInput(CreatureType creatureType)
    {
        if (inputList.Count < 2)
        {
            inputList.Add(creatureType);
            UpdateInputDisplay();
            outputSlot.ClearSlot();
            return true;
        }

        return false;
    }

    public bool RemoveInput(CreatureType type)
    {
        if (inputList.Contains(type))
        {
            inputList.Remove(type);
            
            return true;
        }

        return false;
    }


    public void UpdateInputDisplay()
    {
        for (int i = 0; i < inputslots.Count; i++)
        {
            if (i < inputList.Count)
            {
                inputslots[i].UpdateDisplay(inputList[i]);
            } else
            {
                inputslots[i].ClearSlot();
            }
        }
    }
}
