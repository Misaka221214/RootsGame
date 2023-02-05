using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCraftBtn : MonoBehaviour
{
    public GameObject craftCanvas;

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
        craftCanvas.gameObject.SetActive(true);
    }
}
