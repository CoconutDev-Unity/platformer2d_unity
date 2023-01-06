using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private bool _isAttack;
    private bool _isAttack2;
    public bool IsAttack { get => _isAttack; }
    public void FinishAttack() {
        _isAttack = false;
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            _isAttack = true;
            animator.SetTrigger("Attack");
        }

        if (Input.GetMouseButtonDown(1)) {
            _isAttack2 = true;
            animator.SetTrigger("Attack2");
        }
    }
}
