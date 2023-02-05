using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RemoveInputBtn : MonoBehaviour, IPointerClickHandler
{
    public InputSlot inputSlot;

    public void OnPointerClick(PointerEventData eventData)
    {
        inputSlot.RemoveFromInput();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
