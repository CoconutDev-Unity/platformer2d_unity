using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float damage = 25f;
    private AttackController _attackcontroller;
    private void Start() {
        _attackcontroller = transform.root.GetComponent<AttackController>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();

        if (enemyHealth != null && _attackcontroller.IsAttack) {
            enemyHealth.ReduceHealth(damage);
        }
    }
}
