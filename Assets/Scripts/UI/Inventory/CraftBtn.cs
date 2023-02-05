using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CraftBtn : MonoBehaviour, IPointerClickHandler
{
    public CraftSystem craftSystem;

    public void OnPointerClick(PointerEventData eventData)
    {
        craftSystem.OnCraft();
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
