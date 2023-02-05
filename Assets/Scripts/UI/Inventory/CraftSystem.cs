using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftSystem : MonoBehaviour
{
    public List<InputSlot> inputslots;

    private List<KeyValuePair<List<CreatureType>, CreatureType>> recipes = new();
    private List<CreatureType> inputList = new();

    private void Awake()
    {
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TestOnly_InitRecipes()
    {
        
    }


    private void InitRecipes() {

    }

    public void OnCraft()
    {

    }

    public void AddInput(CreatureType creatureType)
    {
        if (inputList.Count < 2)
        {
            inputList.Add(creatureType);
        }
    }

    public void UpdateDisplay()
    {

    }
}
