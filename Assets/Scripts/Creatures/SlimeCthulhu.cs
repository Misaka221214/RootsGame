using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeCthulhu : Creature {
    public float health = CreatureConstants.HEALTH_HIGH;
    public float mass = CreatureConstants.MASS_LOW;
    public float velocity = CreatureConstants.VELOCITY_LOW;
    public int ammo = CreatureConstants.AMMO_LOW;
    public float xDirection = 1;

    private GameObject explosion;
    private float explosionDeltaTime = 2f;


    public void Start() {
        creatureType = CreatureType.SLIME_CTHULHU;
        explosion = Resources.Load("Prefabs/Projectiles/Explosion") as GameObject;

        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    public void FixedUpdate() {
        wanderingDirectionDeltaTimer -= Time.deltaTime;
        explosionDeltaTime -= Time.deltaTime;
        Act();
        SearchEnemy();
    }

    protected override void Act() {
        Move();
    }

    protected override void Move() {
        Walk();
        Climb();
    }

    protected override void RangeAttack() {

    }

    public override void TakeDamage(int damage) {
        health -= damage;

        if (health <= 0f) {
            Die();
        }
    }

    public override void Die() {
        if (gameObject.CompareTag("Enemy")) {
            inventoryManager = GameObject.Find("InventoryManager");
            inventoryManager.GetComponent<InventoryManager>().AddInventory(creatureType);
        }
        rb.AddForce(new Vector2(CreatureConstants.VELOCITY_LOW * xDirection, 0), ForceMode2D.Impulse);
        Invoke(nameof(ExplodeAndDie), 2f);
    }

    private void ExplodeAndDie() {
        GameObject explod = Instantiate(explosion, transform.position, Quaternion.identity);
        explod.tag = tag;
        Destroy(transform.gameObject);
    }

    private void Walk() {
        float dir = GetTargetDirection().x;
        xDirection = dir == 0 ? xDirection : dir;

        if (xDirection > 0) {
            xDirection = 1;
        } else {
            xDirection = -1;
        }

        rb.AddForce(new Vector2(CreatureConstants.VELOCITY_LOW * xDirection, 0));
    }

    private void Climb() {
        if (Mathf.Abs(rb.velocity.x) < CreatureConstants.STUCK_VELOCITY_THRESHOLD) {
            rb.AddForce(new Vector2(0, CreatureConstants.VELOCITY_LOW * 30));
        }
    }
}
