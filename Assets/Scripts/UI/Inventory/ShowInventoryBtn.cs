using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInventoryBtn : MonoBehaviour
{
    public GameObject inventoryCanvas;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(Show);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Show()
    {
        inventoryCanvas.gameObject.SetActive(true);
    }
}
