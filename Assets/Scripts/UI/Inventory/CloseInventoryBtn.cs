using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CloseInventoryBtn : MonoBehaviour, IPointerClickHandler
{
    public WorldInventoryUI worldInventory;

    public void OnPointerClick(PointerEventData eventData)
    {
        worldInventory.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
