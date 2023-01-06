using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float walkDistance = 6f;
    [SerializeField] private float walkSpeed = 0.06f;
    [SerializeField] private float timeToWait = 2f;
    [SerializeField] private float timeToChase = 10f;
    [SerializeField] private float minDistanceToPlayer = 1.5f ;

    private Rigidbody2D _rb;
    private Transform _playerTransform;
    private Vector2 _leftBoundaryPosition;
    private Vector2 _rightBoundaryPosition;
    private Vector2 nextPoint;
    
    private bool _isFacingRight = true;
    private bool _isWait = false;
    private float _waitTime;
    private float _chaseTime;
    private bool _isChasingPlayer;

    public bool IsFacingRight {
        get => _isFacingRight;
    }

    public void StartChaisingPlayer(){
        _isChasingPlayer = true;
        _chaseTime = timeToChase;
    }

    private void Start() {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _waitTime = timeToWait;
        _rb = GetComponent<Rigidbody2D>();
        _chaseTime = timeToChase;

        _leftBoundaryPosition = transform.position;
        _rightBoundaryPosition = _leftBoundaryPosition + Vector2.right * walkDistance;
    }

    private void Update() {
        if (_isChasingPlayer) {
            StartChaisingTimer();
        }

        if (!_isChasingPlayer) {
            walkSpeed = 2f;
        }

        if (_isWait && !_isChasingPlayer) {
            Wait();
        }

        if (ShouldWait()) {
            _isWait = true;
        }
    }

    private void FixedUpdate() {
        nextPoint = Vector2.right * walkSpeed * Time.fixedDeltaTime;

        if (Mathf.Abs(DistanceToPlayer()) < minDistanceToPlayer && _isChasingPlayer) {
            return;
        }

        if(_isChasingPlayer) {
            walkSpeed = 5f;
            ChasePlayer();
        }

        if (!_isWait && !_isChasingPlayer) {
            Patrol();
        }
    }

    private void Patrol() {
        if (!_isFacingRight) {
            nextPoint.x *= -1;
        }
        
        _rb.MovePosition(((Vector2)transform.position + nextPoint));
    }

    private void ChasePlayer() {
        float distance = DistanceToPlayer();
        
        if (distance < 0) {
            nextPoint.x *= -1;
        }

        if (distance > 0.2f && !_isFacingRight) {
            Flip();
        } else if (distance < 0.2f && _isFacingRight) {
            Flip();
        }

        _rb.MovePosition((Vector2)transform.position + nextPoint);
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(_leftBoundaryPosition, _rightBoundaryPosition);
    }

    void Flip() {
        _isFacingRight = !_isFacingRight;
        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }

    private float DistanceToPlayer() {
        return _playerTransform.position.x - transform.position.x;
    }

    private void Wait() {
        _waitTime -= Time.deltaTime;

        if (_waitTime < 0f) {
            _waitTime = timeToWait;
            _isWait = false;
            Flip();
        }
    }

    private void StartChaisingTimer() {
        _chaseTime -= Time.deltaTime;

        if (_chaseTime < 0f) {
            _isChasingPlayer = false; 
            _chaseTime = timeToChase;
        }
    }

    private bool ShouldWait() {
        bool isOutOfRightBoundary = _isFacingRight && transform.position.x >= _rightBoundaryPosition.x;
        bool isOutOfLeftBoundary = !_isFacingRight && transform.position.x <= _leftBoundaryPosition.x;

        return isOutOfLeftBoundary || isOutOfRightBoundary;
    }
}