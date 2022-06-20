using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;

    [SerializeField] private Vector2 _friction = new Vector2(0.1f, 0f);

    [SerializeField] private float _speed = 5f;

    [SerializeField] private float _jumpForce = 2f;

    private void Update()
    {
        HandleJump();
        HandleMoviment();
    }

    private void HandleMoviment()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _rb.velocity = new Vector2(-_speed, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            _rb.velocity = new Vector2(_speed, 0);
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
            _rb.velocity = Vector2.up * _jumpForce;
        }
    }
}
