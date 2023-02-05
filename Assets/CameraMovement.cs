using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private bool moving = false;
    private Vector2 mousePos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            moving = true;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if(Input.GetMouseButtonUp(1))
        {
            moving = false;
        }

        if (moving)
        {
            Vector2 currMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 currCamaera = gameObject.transform.position;
            currCamaera += new Vector3(mousePos.x - currMouse.x, mousePos.y - currMouse.y);
            gameObject.transform.position = currCamaera;
        }
    }
}
