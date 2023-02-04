using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Creature : MonoBehaviour {
    public GameObject target;
    public Rigidbody2D rb;
    public bool isAlly;
    public CreatureType creatureType;

    private float stuckSaverDeltaTimer = CreatureConstants.STUCK_COOLDOWN;

    protected abstract void Act();
    protected abstract void Move();
    protected abstract void MeleeAttack();
    protected abstract void RangeAttack();
    public abstract void TakeDamage(int damage);

    private void Start() {
        isAlly = GetComponent<Creature>().CompareTag("Ally");
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    protected void StuckSaver() {
        stuckSaverDeltaTimer--;
        if (stuckSaverDeltaTimer < 0f && Mathf.Abs(rb.velocity.x) < CreatureConstants.STUCK_VELOCITY_THRESHOLD) {
            stuckSaverDeltaTimer = CreatureConstants.STUCK_COOLDOWN;
            rb.AddForce(new Vector2(0, CreatureConstants.STUCK_JUMP * 5));
        }
    }

    public virtual void Die() {
        Destroy(transform.gameObject);
    }

    public void PushBack(int direction, Vector2 force) {
        if (rb != null) {
            rb.AddForce(force * direction);
        }
    }

    protected void SearchTarget() {

    }
}
