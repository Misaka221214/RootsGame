using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRandomForce : MonoBehaviour {
    public GameObject go;

    void FixedUpdate() {
        if (Input.GetMouseButtonDown(1)) {
            go.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-10, 10), 10), ForceMode2D.Impulse);
        }
    }
}
