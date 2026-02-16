using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Mover : MonoBehaviour
{
    private Vector3 _direction;
    private float _speed;

    private Rigidbody _rigidbody;
    
    private void Awake()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void SetupMovement(Vector3 direction, float speed)
    {
        _direction = direction.normalized;
        _speed = speed;
    }

    private void Move()
    {
        if (_direction == Vector3.zero)
            return;

        _rigidbody.velocity = _direction * _speed;
    }
}
