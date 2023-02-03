using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doritos : Creature {
    public float health = CreatureConstants.HEALTH_LOW;
    public float mass = CreatureConstants.MASS_LOW;
    public float velocity = CreatureConstants.VELOCITY_LOW;
    public int ammo = CreatureConstants.AMMO_LOW;

    public void FixedUpdate() {
        Act();
    }

    protected override void Act() {
        rb.freezeRotation = true;
        Move();
    }

    protected override void Move() {
        Walk();
        StuckSaver();
    }

    protected override void MeleeAttack() {

    }

    protected override void RangeAttack() {

    }

    private void Walk() {
        rb.AddForce(new Vector2(CreatureConstants.VELOCITY_LOW, 0));
    }

    private void Climb() {

    }
}
