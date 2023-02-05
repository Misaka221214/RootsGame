using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenDoritos : Creature {
    public float health = CreatureConstants.HEALTH_LOW;
    public float mass = CreatureConstants.MASS_LOW;
    public float velocity = CreatureConstants.VELOCITY_LOW;
    public int ammo = CreatureConstants.AMMO_LOW;

    private GameObject greenDoritosChip;
    private float doritosRangeDeltaTime = CreatureConstants.RANGE_COOLDOWN;

    public float xDirection = 1;
    public float yDirection = 1;

    public void Start() {
        creatureType = CreatureType.GREEN_DORITOS;
        greenDoritosChip = Resources.Load("Prefabs/Projectiles/GreenDoritosChip") as GameObject;

        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    public void FixedUpdate() {
        doritosRangeDeltaTime -= Time.deltaTime;
        wanderingDirectionDeltaTimer -= Time.deltaTime;
        Act();
        SearchEnemy();
    }

    protected override void Act() {
        Move();
        RangeAttack();
    }

    protected override void Move() {
        Fly();
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

    private void Fly() {
        Vector2 vec = GetTargetDirection();
        xDirection = vec.x == 0 ? xDirection : vec.x;

        if (xDirection > 0) {
            xDirection = 1;
        } else {
            xDirection = -1;
        }

        yDirection = vec.y == 0 ? yDirection : vec.y;

        if (yDirection > 0) {
            yDirection = 1;
        } else {
            yDirection = -1;
        }

        rb.velocity = new Vector2(CreatureConstants.VELOCITY_LOW * xDirection, CreatureConstants.VELOCITY_LOW * yDirection);
    }
}
