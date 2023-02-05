using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OutputSlot : MonoBehaviour
{
    public Image contentImg;
    public TextMeshProUGUI outputText;
    public GameObject bg;

    void Start()
    {
        ClearSlot();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowOutput(CreatureType creature)
    {
        Sprite creatureSprite = CreatureData.CreatureSprite[creature];
        contentImg.sprite = creatureSprite;
        contentImg.gameObject.SetActive(true);
        outputText.gameObject.SetActive(true);
        bg.gameObject.SetActive(true);
    }

    public void ClearSlot()
    {
        contentImg.gameObject.SetActive(false);
        outputText.gameObject.SetActive(false);
        bg.gameObject.SetActive(false);
    }
}
