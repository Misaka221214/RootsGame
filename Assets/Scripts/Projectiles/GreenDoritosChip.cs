using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenDoritosChip : MonoBehaviour {
    private float deleteTime = 15f;
    private float poisionTime = 15f;
    private float tickerCooldown = 1f;
    private GameObject targetGo;

    void FixedUpdate() {
        deleteTime -= Time.deltaTime;
        poisionTime -= Time.deltaTime;
        tickerCooldown -= Time.deltaTime;
        DeleteProjectile();
        Poisionate();
        ReducePoisionatedHealth();
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
        if (targetGo == null && (go.CompareTag("Ally") || go.CompareTag("Enemy")) && !go.CompareTag(tag)) {
            targetGo = go;
        }
    }

    private void Poisionate() {
        if (targetGo != null) {
            poisionTime = 15f;
        }
    }

    private void ReducePoisionatedHealth() {
        if (poisionTime >= 0f && targetGo != null) {
            if (tickerCooldown <= 0f) {
                tickerCooldown = 1f;
                targetGo.GetComponent<Creature>().TakeDamage(1);
            }
        }
    }
}
