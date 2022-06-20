using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;

    [SerializeField] private Vector2 _velocity;

    [SerializeField] private float _speed = 5f;

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //_rb.MovePosition(_rb.position - _velocity * Time.deltaTime);
            _rb.velocity = new Vector2(-_speed, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //_rb.MovePosition(_rb.position + _velocity * Time.deltaTime);
            _rb.velocity = new Vector2(_speed, 0);
        }
    }
}
