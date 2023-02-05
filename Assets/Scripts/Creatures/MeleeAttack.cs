using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour {
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
                case CreatureType.RABBIT:
                    creature.TakeDamage(5);
                    break;
                case CreatureType.NEYMAR:
                    creature.TakeDamage(5);
                    break;
                case CreatureType.CTHULHU:
                    creature.TakeDamage(5);
                    break;
                case CreatureType.SLIME_CTHULHU:
                    creature.TakeDamage(5);
                    break;
                case CreatureType.SLIME_NEYMAR:
                    creature.TakeDamage(5);
                    break;
                case CreatureType.NYAR:
                    creature.TakeDamage(5);
                    break;
                case CreatureType.GREEN_NYAR:
                    creature.TakeDamage(5);
                    break;
                case CreatureType.GREEN_DORITOS:
                    creature.TakeDamage(5);
                    break;
                case CreatureType.GREEN_DORITOS_RABBIT:
                    creature.TakeDamage(5);
                    break;
                case CreatureType.GREEN_RABBIT_OCTOPUS:
                    int draw1 = Random.Range(0, 100);
                    if (draw1 < 20) {
                        creature.TakeDamage(100);
                        GetComponentInParent<Creature>().TakeDamage(-10);
                    } else {
                        creature.TakeDamage(5);
                    }
                    break;
                case CreatureType.DORITOS_RABBIT:
                    creature.TakeDamage(5);
                    break;
                case CreatureType.TRASH:
                    creature.TakeDamage(5);
                    break;
                case CreatureType.DORITOS_OCTOPUS:
                    creature.TakeDamage(5);
                    int draw2 = Random.Range(0, 100);
                    if (draw2 < 20) {
                        meleeDeltaTimer = 0f;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
