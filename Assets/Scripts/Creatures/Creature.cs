using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Creature : MonoBehaviour {
    public GameObject target;
    public Rigidbody2D rb;

    protected abstract void Act();
    protected abstract void Move();
    protected abstract void MeleeAttack();
    protected abstract void RangeAttack();

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    protected void SearchTarget() {

    }
}
