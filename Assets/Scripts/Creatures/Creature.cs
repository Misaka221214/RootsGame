using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Creature : MonoBehaviour {
    public GameObject target;
    public Rigidbody2D rb;
    public bool isAlly;
    public CreatureType creatureType;

    private float stuckSaverDeltaTimer = CreatureConstants.STUCK_COOLDOWN;
    private float searchEnemyDeltaTimer = 3f;
    protected float wanderingDirectionDeltaTimer = CreatureConstants.WANDERING_COOLDOWN;

    protected readonly List<int> direction = new() { -1, 1 };

    protected abstract void Act();
    protected abstract void Move();
    protected abstract void RangeAttack();
    public abstract void TakeDamage(int damage);

    private void Start() {
        isAlly = GetComponent<Creature>().CompareTag("Ally");
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    protected void StuckSaver() {
        stuckSaverDeltaTimer -= Time.deltaTime;
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

    public Vector2 GetTargetDirection() {
        if (target == null) {
            if (wanderingDirectionDeltaTimer <= 0f) {
                wanderingDirectionDeltaTimer = CreatureConstants.WANDERING_COOLDOWN;
                return new Vector2(direction[Random.Range(0, 2)], direction[Random.Range(0, 2)]);
            }
            return new Vector2(0, 0);
        } else {
            return target.transform.position - transform.position;
        }
    }

    public void SearchEnemy() {
        searchEnemyDeltaTimer -= Time.deltaTime;

        if(searchEnemyDeltaTimer <= 0) {
            searchEnemyDeltaTimer = 3f;

            GameObject[] gos = GameObject.FindGameObjectsWithTag(isAlly ? "Enemy" : "Ally");
            foreach (GameObject go in gos) {
                Vector3 vec = transform.position - go.transform.position;
                float distance = Mathf.Abs(vec.x) + Mathf.Abs(vec.y);

                if (target == null && distance < 20) {
                    target = go;
                    break;
                }

                if (target.Equals(go) && distance > 20) {
                    target = null;
                    break;
                }
            }
        }
    }
}
