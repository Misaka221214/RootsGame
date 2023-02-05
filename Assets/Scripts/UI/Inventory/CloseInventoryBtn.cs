using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CloseInventoryBtn : MonoBehaviour, IPointerClickHandler
{
    public GameObject worldInventoryCanvas;

    public void OnPointerClick(PointerEventData eventData)
    {
        worldInventoryCanvas.gameObject.SetActive(false);
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
