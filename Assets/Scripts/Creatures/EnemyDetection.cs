using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour {
    public Creature parentCreature;
    public string parentTag;

    void Start() {
        parentCreature = GetComponentInParent<Creature>();
        parentTag = parentCreature.tag;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        AddTarget(collision.gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision) {
        AddTarget(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision) {
        RemoveTarget(collision.gameObject);
    }

    private void AddTarget(GameObject go) {
        if (parentCreature.target == null && (go.CompareTag("Ally") || go.CompareTag("Enemy")) && !go.CompareTag(parentTag)) {
            parentCreature.target = go;
        }
    }

    private void RemoveTarget(GameObject go) {
        if (parentCreature.target != null && (go.CompareTag("Ally") || go.CompareTag("Enemy")) && parentCreature.target.Equals(go)) {
            parentCreature.target = null;
        }
    }
}
