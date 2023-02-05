using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float hoverAmount = 0.05f;
    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<RectTransform>().localScale = new Vector3(GetComponent<RectTransform>().localScale.x + hoverAmount, GetComponent<RectTransform>().localScale.y + hoverAmount, GetComponent<RectTransform>().localScale.z + hoverAmount);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<RectTransform>().localScale = new Vector3(GetComponent<RectTransform>().localScale.x - hoverAmount, GetComponent<RectTransform>().localScale.y - hoverAmount, GetComponent<RectTransform>().localScale.z - hoverAmount);
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
