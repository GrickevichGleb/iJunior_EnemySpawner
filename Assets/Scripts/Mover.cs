using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Mover : MonoBehaviour
{
    private float _moveSpeed;
    private float _rotationSpeed = 120f;
    private float _reachRadius = 1f;
    
    private Transform _target;
    
    private Rigidbody _rigidbody;
    
    private void Awake()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        _reachRadius = GetComponent<Collider>().bounds.extents.z;
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void SetupMovement(Transform target, float speed, float rotationSpeed)
    {
        _target = target;
        
        _moveSpeed = speed;
        _rotationSpeed = rotationSpeed;
    }
    
    public bool HasReachedTarget()
    {
        if (Vector3.Distance(transform.position, _target.position) <= _reachRadius)
            return true;

        return false;
    }

    private void Move()
    {
        if (_target == null)
            return;

        if (HasReachedTarget())
            return;

        RotateTowardsTarget();
        _rigidbody.velocity = transform.forward * _moveSpeed;
    }

    private void RotateTowardsTarget()
    {
        Vector3 direction = (_target.position - transform.position).normalized;
        float step = _rotationSpeed * Time.deltaTime;
        
        Quaternion rotation = Quaternion.RotateTowards(
            transform.rotation, Quaternion.LookRotation(direction), step );
        
        _rigidbody.MoveRotation(rotation);
    }

    
}
