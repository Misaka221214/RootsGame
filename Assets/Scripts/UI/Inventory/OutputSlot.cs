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

    private void OnEnable()
    {
        ClearSlot();
    }

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
        GameObject go = CreatureData.PlayerCreaturePrefabs[creature] as GameObject;
        Sprite creatureSprite = go.GetComponent<SpriteRenderer>().sprite;
        contentImg.sprite = creatureSprite;
        contentImg.color = go.GetComponent<SpriteRenderer>().color;

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
