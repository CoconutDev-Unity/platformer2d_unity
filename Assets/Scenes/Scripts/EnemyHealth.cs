using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float Health = 100f;

    private Animator _animator;

    private void Start() {
        _animator = GetComponent<Animator>();
    }

    public void ReduceHealth(float damage) {
        Health -= damage;

        _animator.SetTrigger("Is_Taking_Damage");

        if (Health <= 0f) {
            Die();
        }
    }
    private void Die() {
        gameObject.SetActive(false);
    }
}
