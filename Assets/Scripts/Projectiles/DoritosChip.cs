using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoritosChip : MonoBehaviour {
    public float deleteTime = 10f;

    void FixedUpdate() {
        deleteTime -= Time.deltaTime;
        DeleteProjectile();
    }

    private void DeleteProjectile() {
        if (deleteTime <= 0f) {
            Destroy(transform.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Damage(collision.gameObject);
    }

    private void OnCollisionStay2D(Collision2D collision) {
        Damage(collision.gameObject);
    }

    private void Damage(GameObject go) {
        if ((go.CompareTag("Ally") || go.CompareTag("Enemy")) && !go.CompareTag(tag)) {
            go.GetComponent<Creature>().TakeDamage(3);
            Destroy(transform.gameObject);
        }
    }
}
