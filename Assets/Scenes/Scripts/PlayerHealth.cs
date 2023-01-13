using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private GameObject GameOverCanvas;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private float totalHealth = 100f;
    [SerializeField] private Animator _animator;

    private float _health;
    [SerializeField] private AudioSource hitSound;

    private void Start() {
        _health = totalHealth;
    }

    public void ReduceHealth(float damage) {
        _health -= damage;
        hitSound.Play();
        InitHealth();
        _animator.SetTrigger("Is_Taking_Damage");
        if (_health <= 0f) {
            Die();
        }
    }

    private void InitHealth() {
        healthSlider.value = _health / totalHealth;
    }

    private void Die() {
        gameObject.SetActive(false);
        GameOverCanvas.SetActive(true);
    }
}
