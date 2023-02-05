using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputSlot : MonoBehaviour
{
    public RemoveInputBtn removeBtn;
    public Image contentImg;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateDisplay(CreatureType creature)
    {

    }

    public void ClearSlot()
    {
        contentImg.gameObject.SetActive(false);
        removeBtn.gameObject.SetActive(false);
    }
}
