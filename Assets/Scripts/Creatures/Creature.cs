using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Creature : MonoBehaviour {
    public GameObject target;
    public Rigidbody2D rb;
    public bool isAlly;

    protected abstract void Act();
    protected abstract void Move();
    protected abstract void MeleeAttack();
    protected abstract void RangeAttack();

    private void Start() {
        isAlly = GetComponent<Creature>().CompareTag("Ally");
        rb = GetComponent<Rigidbody2D>();
    }

    protected void StuckSaver() {
        if (Mathf.Abs(rb.velocity.x) < CreatureConstants.STUCK_VELOCITY_THRESHOLD) {
            rb.AddForce(new Vector2(0, CreatureConstants.STUCK_JUMP));
        }
    }

    protected void SearchTarget() {

    }
}
