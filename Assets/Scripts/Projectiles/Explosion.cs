using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {
    private float deleteTime = 1f;

    void FixedUpdate() {
        deleteTime -= Time.deltaTime;
        DeleteProjectile();
    }

    private void DeleteProjectile() {
        if (deleteTime <= 0f) {
            Destroy(transform.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Damage(collision.gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision) {
        Damage(collision.gameObject);
    }

    private void Damage(GameObject go) {
        if ((go.CompareTag("Ally") || go.CompareTag("Enemy")) && !go.CompareTag(tag)) {
            go.GetComponent<Creature>().TakeDamage(3);
            Destroy(transform.gameObject);
        }
    }
}
