using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public Image itemImg;
    public TextMeshProUGUI quantityTxt;

    public TextMeshProUGUI debugNameTxt;
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
            Sprite creatureSprite = CreatureData.CreatureSprite[creature];
            itemImg.sprite = creatureSprite;
            debugNameTxt.text = creature.ToString();
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
}
