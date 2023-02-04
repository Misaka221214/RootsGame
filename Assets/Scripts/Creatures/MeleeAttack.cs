using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public string parentTag;
    public Creature parentCreature;

    private float meleeDeltaTimer = CreatureConstants.MELEE_COOLDOWN;

    public void Start() {
        parentCreature = GetComponentInParent<Creature>();
        parentTag = parentCreature.tag;
    }

    public void FixedUpdate() {
        meleeDeltaTimer--;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        GameObject gameObject = collision.gameObject;
        DealDamage(gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision) {
        GameObject gameObject = collision.gameObject;
        DealDamage(gameObject);
    }

    private void DealDamage(GameObject gameObject) {
        if (meleeDeltaTimer < 0f && (gameObject.CompareTag("Ally") || gameObject.CompareTag("Enemy")) && !gameObject.CompareTag(parentTag)) {
            meleeDeltaTimer = CreatureConstants.MELEE_COOLDOWN;
            Creature creature = gameObject.GetComponent<Creature>();

            switch (parentCreature.creatureType) {
                case CreatureType.DORITOS:
                    creature.TakeDamage(5);
                    break;
                case CreatureType.SLIME:
                    creature.TakeDamage(5);
                    break;
                default:
                    break;
            }
        }
    }
}
