using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doritos : Creature {
    public float health = CreatureConstants.HEALTH_LOW;
    public float mass = CreatureConstants.MASS_LOW;
    public float velocity = CreatureConstants.VELOCITY_LOW;
    public int ammo = CreatureConstants.AMMO_LOW;

    private GameObject doritosChip;
    private float doritosRangeDeltaTime = CreatureConstants.RANGE_COOLDOWN;

    public float xDirection = 1;
    public float yDirection = 1;

    public void Start() {
        creatureType = CreatureType.DORITOS;
        doritosChip = Resources.Load("Prefabs/Projectiles/DoritosChip") as GameObject;

        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    public void FixedUpdate() {
        doritosRangeDeltaTime -= Time.deltaTime;
        wanderingDirectionDeltaTimer -= Time.deltaTime;
        Act();
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
            GameObject chip = Instantiate(doritosChip, transform.position + new Vector3(0, 2, 0), Quaternion.identity);
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
        yDirection = vec.y == 0 ? yDirection : vec.y;
        rb.velocity = new Vector2(CreatureConstants.VELOCITY_LOW * xDirection, CreatureConstants.VELOCITY_LOW * yDirection);
    }
}
