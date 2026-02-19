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
    
    private Transform _destination;
    
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

    public void SetupMover(float speed, float rotationSpeed)
    {
        _moveSpeed = speed;
        _rotationSpeed = rotationSpeed;
    }

    public void SetDestination(Transform destination)
    {
        _destination = destination;
    }
    
    public bool HasReachedDestination()
    {
        if (_destination == null)
            return false;
        
        if (Vector3.Distance(transform.position, _destination.position) <= _reachRadius)
            return true;

        return false;
    }

    private void Move()
    {
        if (_destination == null)
            return;

        if (HasReachedDestination())
            return;

        RotateTowards(_destination);
        _rigidbody.velocity = transform.forward * _moveSpeed;
    }

    private void RotateTowards(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        float step = _rotationSpeed * Time.deltaTime;
        
        Quaternion rotation = Quaternion.RotateTowards(
            transform.rotation, Quaternion.LookRotation(direction), step );
        
        _rigidbody.MoveRotation(rotation);
    }

    
}
