using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : Creature {
    public float health = CreatureConstants.HEALTH_HIGH;
    public float mass = CreatureConstants.MASS_LOW;
    public float velocity = CreatureConstants.VELOCITY_LOW;
    public int ammo = CreatureConstants.AMMO_LOW;
    public float xDirection = 1;

    private float jumpDeltaTime = CreatureConstants.RABBIT_JUMP_COOLDOWN;

    public void Awake() {
        creatureType = CreatureType.RABBIT;
    }

    public void FixedUpdate() {
        wanderingDirectionDeltaTimer -= Time.deltaTime;
        jumpDeltaTime -= Time.deltaTime;
        Act();
    }

    protected override void Act() {
        Move();
    }

    protected override void Move() {
        Jump();
    }

    protected override void RangeAttack() {

    }

    public override void TakeDamage(int damage) {
        health -= damage;

        if (health <= 0f) {
            Die();
        }
    }

    private void Jump() {
        float dir = GetTargetDirection().x;
        xDirection = dir == 0 ? xDirection : dir;
        if (jumpDeltaTime <= 0f) {
            jumpDeltaTime = CreatureConstants.RABBIT_JUMP_COOLDOWN;
            rb.AddForce(new Vector2(CreatureConstants.VELOCITY_LOW * xDirection, CreatureConstants.VELOCITY_LOW * 2), ForceMode2D.Impulse);
        }
    }
}
