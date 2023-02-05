using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EndCraftSessionBtn : MonoBehaviour, IPointerClickHandler
{
    public GameObject craftCanvas;

    public void OnPointerClick(PointerEventData eventData)
    {
        craftCanvas.gameObject.SetActive(false);
        GameStatics.IncreamentTurnCount();
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
