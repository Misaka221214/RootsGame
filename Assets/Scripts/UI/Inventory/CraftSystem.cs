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
        recipes.Add(new KeyValuePair<List<CreatureType>, CreatureType>(
            new List<CreatureType>() { CreatureType.NEYMAR, CreatureType.SLIME }, CreatureType.SLIME_NEYMAR));

        recipes.Add(new KeyValuePair<List<CreatureType>, CreatureType>(
            new List<CreatureType>() { CreatureType.RABBIT, CreatureType.DORITOS }, CreatureType.DORITOS_RABBIT));

        recipes.Add(new KeyValuePair<List<CreatureType>, CreatureType>(
            new List<CreatureType>() { CreatureType.CTHULHU, CreatureType.SLIME }, CreatureType.SLIME_CTHULHU));

        recipes.Add(new KeyValuePair<List<CreatureType>, CreatureType>(
            new List<CreatureType>() { CreatureType.NEYMAR, CreatureType.CTHULHU }, CreatureType.NYAR));

        recipes.Add(new KeyValuePair<List<CreatureType>, CreatureType>(
            new List<CreatureType>() { CreatureType.DORITOS, CreatureType.SLIME }, CreatureType.GREEN_DORITOS));

        recipes.Add(new KeyValuePair<List<CreatureType>, CreatureType>(
            new List<CreatureType>() { CreatureType.DORITOS, CreatureType.CTHULHU }, CreatureType.DORITOS_OCTOPUS));

        recipes.Add(new KeyValuePair<List<CreatureType>, CreatureType>(
            new List<CreatureType>() { CreatureType.SLIME_CTHULHU, CreatureType.NYAR }, CreatureType.GREEN_NYAR));

        recipes.Add(new KeyValuePair<List<CreatureType>, CreatureType>(
            new List<CreatureType>() { CreatureType.DORITOS_RABBIT, CreatureType.DORITOS_OCTOPUS }, CreatureType.GREEN_RABBIT_OCTOPUS));

        recipes.Add(new KeyValuePair<List<CreatureType>, CreatureType>(
            new List<CreatureType>() { CreatureType.DORITOS_RABBIT, CreatureType.GREEN_DORITOS }, CreatureType.GREEN_DORITOS_RABBIT));
    }

    public void OnCraft()
    {
        if (inputList.Count == 2)
        {
            var output = GetRecipeOutput();
            outputSlot.ShowOutput(output);
            inventoryManager.AddInventory(output);
            inventoryUI.UpdateDisplay();
            inputList.Clear();
            UpdateInputDisplay();
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
