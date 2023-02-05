using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerClickHandler
{
    public Image itemImg;
    public TextMeshProUGUI quantityTxt;

    public TextMeshProUGUI debugNameTxt;

    private CraftSystem craftSystem;
    private InventoryManager inventoryManager;
    private InventoryUI InventoryUI;
    private CreatureType creatureType;

    private void Awake()
    {
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

    public void UpdateDisplay(CreatureType creature, int quantity)
    {
        if (CreatureData.CreatureSprite.ContainsKey(creature))
        {
            GameObject go = CreatureData.PlayerCreaturePrefabs[creature] as GameObject;
            Sprite creatureSprite = go.GetComponent<SpriteRenderer>().sprite;
            itemImg.sprite = creatureSprite;
            itemImg.color = go.GetComponent<SpriteRenderer>().color;
            debugNameTxt.text = creature.ToString();
            creatureType = creature;
        } else
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

    public void AddToInput()
    {
        if (craftSystem.AddInput(creatureType))
        {
            inventoryManager.RemoveCreature(creatureType);
            InventoryUI.UpdateDisplay();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        AddToInput();

    }
}
