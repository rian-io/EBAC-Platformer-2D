using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Animator _animator;

    [Header("Movement")]
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _runningSpeed = 10f;
    [SerializeField] private float _jumpForce = 2f;

    [Header("Animation")]
    [SerializeField] private float _turnDuration = 0.3f;

    private Vector3 _leftDirection = new Vector3(-1, 1, 1);
    private Vector3 _rightDirection = new Vector3(1, 1, 1);

    private float _currentSpeed;
    private float _speedModifier;
    private bool _isGrounded;

    private void Update()
    {
        HandleJump();
        HandleMoviment();
        HandleAnimation();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (!_isGrounded) {
            _isGrounded = true;
            _animator.ResetTrigger("Jumping");
        }
    }

    private void HandleMoviment()
    {
        _speedModifier = Input.GetKey(KeyCode.LeftShift) ? _runningSpeed : _speed;
        _currentSpeed = Input.GetAxisRaw("Horizontal") * _speedModifier;

        if (_currentSpeed > 0)
            transform.DOScale(_rightDirection, _turnDuration);
        else if (_currentSpeed < 0)
            transform.DOScale(_leftDirection, _turnDuration);

        _rb.velocity = new Vector2(_currentSpeed, _rb.velocity.y);
    }

    private void HandleJump()
    {
        if (_isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            _isGrounded = false;
            _rb.velocity = Vector2.up * _jumpForce;
            _animator.SetTrigger("Jumping");
        }
    }

    private void HandleAnimation()
    {
        if (_isGrounded && _rb.velocity.x != 0.0f)
            _animator.SetBool("Walking", true);
        else
            _animator.SetBool("Walking", false);
    }
}
