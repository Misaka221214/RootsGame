using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenRabbitOctopus : Creature
{
    public float health = CreatureConstants.HEALTH_HIGH;
    public float mass = CreatureConstants.MASS_LOW;
    public float velocity = CreatureConstants.VELOCITY_LOW;
    public int ammo = CreatureConstants.AMMO_LOW;
    public float xDirection = 1;

    public void Awake() {
        creatureType = CreatureType.GREEN_RABBIT_OCTOPUS;
    }

    public void FixedUpdate() {
        wanderingDirectionDeltaTimer -= Time.deltaTime;
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
