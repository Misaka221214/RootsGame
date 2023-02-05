using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenNyar : Creature {
    public float health = CreatureConstants.HEALTH_HIGH;
    public float mass = CreatureConstants.MASS_LOW;
    public float velocity = CreatureConstants.VELOCITY_LOW;
    public int ammo = CreatureConstants.AMMO_LOW;
    public float xDirection = 1;

    private GameObject greenDoritosChip;
    private GameObject explosion;
    private float jumpDeltaTime = CreatureConstants.RABBIT_JUMP_COOLDOWN;
    private float doritosRangeDeltaTime = CreatureConstants.RANGE_COOLDOWN;

    public void Start() {
        creatureType = CreatureType.GREEN_NYAR;
        greenDoritosChip = Resources.Load("Prefabs/Projectiles/GreenDoritosChip") as GameObject;
        explosion = Resources.Load("Prefabs/Projectiles/Explosion") as GameObject;

        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    public void FixedUpdate() {
        doritosRangeDeltaTime -= Time.deltaTime;
        wanderingDirectionDeltaTimer -= Time.deltaTime;
        jumpDeltaTime -= Time.deltaTime;
        Act();
        SearchEnemy();
    }

    protected override void Act() {
        Move();
        RangeAttack();
    }

    protected override void Move() {
        Jump();
    }

    protected override void RangeAttack() {
        if (doritosRangeDeltaTime < 0 && target != null) {
            doritosRangeDeltaTime = CreatureConstants.RANGE_COOLDOWN;
            GameObject chip = Instantiate(greenDoritosChip, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            chip.tag = tag;
            chip.GetComponent<Rigidbody2D>().AddForce(new Vector2(200, 200));
        }
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
        GameObject explod = Instantiate(explosion, transform.position, Quaternion.identity);
        explod.tag = tag;
    }

    private void Jump() {
        float dir = GetTargetDirection().x;
        xDirection = dir == 0 ? xDirection : dir;

        if (xDirection > 0) {
            xDirection = 1;
        } else {
            xDirection = -1;
        }

        if (jumpDeltaTime <= 0f) {
            jumpDeltaTime = CreatureConstants.RABBIT_JUMP_COOLDOWN;
            rb.AddForce(new Vector2(CreatureConstants.VELOCITY_LOW * xDirection, CreatureConstants.VELOCITY_LOW * 2), ForceMode2D.Impulse);
        }
    }
}
