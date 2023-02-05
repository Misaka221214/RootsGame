using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAndDrag : MonoBehaviour {
    //click and drag creatures

    private bool isDragged; //mouse drags obj
    private bool isTriggeredGround; //obj is trigged to ground

    Vector2 mousePos = new Vector2();
    Vector2 lastMousePos = new Vector2();

    private float dragSpeed = 1.5f;


    private void Start() {
        lastMousePos = transform.position;
    }
    // Update is called once per frame
    void FixedUpdate() {
        if (isDragged == true && isTriggeredGround == false) {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePos * dragSpeed * Time.deltaTime);
        } else if (isDragged == true && isTriggeredGround == true) {
            transform.Translate(lastMousePos);
        }
    }

    public void OnMouseDown() {
        isDragged = true;
    }
    public void OnMouseUp() {
        isDragged = false;
    }

    private void OnTriggerEnter(Collider other) {
        isTriggeredGround = true;
    }
    private void OnTriggerExit(Collider other) {
        isTriggeredGround = false;
    }

}