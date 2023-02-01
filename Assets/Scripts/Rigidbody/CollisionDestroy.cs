using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDestroy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) {
        DestroyOnCollision(collision);
    }

    private void OnCollisionStay2D(Collision2D collision) {
        DestroyOnCollision(collision);
    }

    private void DestroyOnCollision(Collision2D collision) {
        if(collision.collider.name == "Circle") {
            Destroy(collision.otherCollider.gameObject);
        }
    }
}
