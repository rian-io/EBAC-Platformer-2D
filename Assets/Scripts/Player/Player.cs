using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody2D _rb;

    [Header("Movement")]
    [SerializeField] private Vector2 _friction = new Vector2(0.1f, 0f);
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _runningSpeed = 10f;
    [SerializeField] private float _jumpForce = 2f;

    [Header("Animation")]
    [SerializeField] private float _jumpScaleX = 0.7f;
    [SerializeField] private float _jumpScaleY = 1.5f;
    [SerializeField] private float _jumpAnimationDuration = 0.3f;
    [SerializeField] private float _groundScaleX = 1.5f;
    [SerializeField] private float _groundScaleY = 0.7f;
    [SerializeField] private float _groundAnimationDuration = 0.3f;
    [SerializeField] private Ease ease = Ease.OutBack;

    private float _currentSpeed;

    private bool _isGrounded;

    private void Update()
    {
        HandleJump();
        HandleMoviment();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (!_isGrounded) {
            _isGrounded = true;

            transform.DOScaleX(_groundScaleX, _groundAnimationDuration).SetEase(ease).OnComplete(() => {
                transform.DOScaleX(1, _groundAnimationDuration).SetEase(ease);
            });
            transform.DOScaleY(_groundScaleY, _groundAnimationDuration).SetEase(ease).OnComplete(() => {
                transform.DOScaleY(1, _groundAnimationDuration).SetEase(ease);
            });
        }
    }

    private void HandleMoviment()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            _currentSpeed = _runningSpeed;
        }
        else
        {
            _currentSpeed = _speed;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _rb.velocity = new Vector2(-_currentSpeed, _rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            _rb.velocity = new Vector2(_currentSpeed, _rb.velocity.y);
        }

        if (_rb.velocity.x > 0)
        {
            _rb.velocity -= _friction;
        }
        else if (_rb.velocity.x < 0)
        {
            _rb.velocity += _friction;
        }
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isGrounded = false;

            _rb.velocity = Vector2.up * _jumpForce;
            transform.localScale = Vector2.one;

            DOTween.Kill(transform);

            HandleScaleJump();
        }
    }

    private void HandleScaleJump()
    {
        transform.DOScaleX(_jumpScaleX, _jumpAnimationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        transform.DOScaleY(_jumpScaleY, _jumpAnimationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }
}
