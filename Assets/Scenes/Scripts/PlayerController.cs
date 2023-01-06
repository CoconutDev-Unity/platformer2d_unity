using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speedx = -1f;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform playerCharacterTransform;

    private float _Horizontal = 0f;
    private bool _isGround = false;
    private bool _isJump = false;
    private bool _isFinish = false;
    private bool _isLeverArm = false;

    private Rigidbody2D _rb;
    private Finish _finish;
    private LeverArm _leverArm;

    const float speedxMultiplier = 50f;
    private bool isFacingRight = true;

    void Start() {
        _rb = GetComponent<Rigidbody2D>();
        _finish = GameObject.FindGameObjectWithTag("Finish").GetComponent<Finish>();
        _leverArm = FindObjectOfType<LeverArm>();
    }

    void Update() {
        _Horizontal = Input.GetAxis("Horizontal"); //-1 : 1
        animator.SetFloat("Speedx", Mathf.Abs(_Horizontal));

        if (Input.GetKey(KeyCode.W) && _isGround) {
            _isJump = true;
        }

        if (Input.GetKeyDown(KeyCode.F)) {
            if (_isFinish) {
                _finish.FinishLevel();
            }

            if (_isLeverArm) {
                _leverArm.ActivateLeverArm();
            }
        }
    }

    void FixedUpdate() {
        _rb.velocity = new Vector2(_Horizontal * speedx * speedxMultiplier * Time.fixedDeltaTime, _rb.velocity.y);

        if (_isJump) {
            _rb.AddForce(new Vector2 (0f, 850f));

            _isGround = false;
            _isJump = false;
        }

        if (_Horizontal > 0f && !isFacingRight) {
            Flip();
        } else if (_Horizontal < 0f && isFacingRight) {
            Flip();
        }
    }
    
    void Flip() {
        isFacingRight = !isFacingRight;
        Vector3 playerScale = playerCharacterTransform.localScale;
        playerScale.x *= -1;
        playerCharacterTransform.localScale = playerScale;
    }

    void OnCollisionEnter2D (Collision2D other) {
        if (other.gameObject.CompareTag("Ground")) {
            _isGround = true;
        }
    }

    private void OnTriggerEnter2D (Collider2D other) {
        LeverArm _leverArmTemp = other.GetComponent<LeverArm>();

        if (other.CompareTag("Finish")) {
            Debug.Log("Worked");
            _isFinish = true;
        }

        if (_leverArmTemp != null) {
            _isLeverArm = true;
        }
    }

    private void OnTriggerExit2D (Collider2D other) {
        LeverArm _leverArmTemp = other.GetComponent<LeverArm>();

        if (other.CompareTag("Finish")) {
            Debug.Log("Not worked");
            _isFinish = false;
        }

        if (_leverArmTemp != null) {
            _isLeverArm = false;
        }
    }
}