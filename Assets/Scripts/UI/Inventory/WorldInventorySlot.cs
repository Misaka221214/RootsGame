using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WorldInventorySlot : MonoBehaviour
{
    public Image itemImg;
    public TextMeshProUGUI quantityTxt;
    public Button spawnButton;

    private CreatureType creatureType = CreatureType.NULL;
    private WorldInventoryUI worldInventory;

    private void Awake()
    {
        worldInventory = FindObjectOfType<WorldInventoryUI>();
    }

    void Start()
    {
        spawnButton.onClick.AddListener(OnSpwanCreature);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSpwanCreature()
    {
        if (creatureType != CreatureType.NULL)
        {
            worldInventory.SpawnCreature(creatureType);
        }
    }

    public void UpdateDisplay(CreatureType creature, int quantity)
    {
        if (CreatureData.CreatureSprite.ContainsKey(creature))
        {
            Sprite creatureSprite = CreatureData.CreatureSprite[creature];
            itemImg.sprite = creatureSprite;
            creatureType = creature;
        }
        else
        {
            Debug.LogError("Cannot find creature sprite");
        }

        quantityTxt.text = quantity.ToString();

        gameObject.SetActive(true);
    }

    public void HideDisplay()
    {
        gameObject.SetActive(false);
    }
}
