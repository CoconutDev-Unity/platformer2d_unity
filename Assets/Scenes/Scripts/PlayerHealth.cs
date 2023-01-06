using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private float totalHealth = 100f;
    [SerializeField] private Animator _animator;

    private float _health;

    private void Start() {
        _health = totalHealth;
    }

    private void Update() {
        healthSlider.value = _health / totalHealth;
    }

    public void ReduceHealth(float damage) {
        _health -= damage;

        _animator.SetTrigger("Is_Taking_Damage");

        if (_health <= 0f) {
            Die();
        }
    }
    private void Die() {
        gameObject.SetActive(false);
    }
}
