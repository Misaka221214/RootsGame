using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCoreEnemy : Creature {
    public float health = CreatureConstants.HEALTH_HIGH;

    public void Awake() {

    }

    public void FixedUpdate() {

    }


    protected override void Act()
    {
        
    }

    protected override void Move()
    {

    }

    protected override void RangeAttack()
    {

    }

    public override void TakeDamage(int damage) {
        health -= damage;

        if (health <= 0f) {
            Die();
        }
    }
}
