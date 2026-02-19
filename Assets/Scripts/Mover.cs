using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Mover : MonoBehaviour
{
    private float _moveSpeed;
    private float _rotationSpeed = 120f;
    private float _reachRadiusSqr = 1f;
    
    private Transform _destination;
    
    private Rigidbody _rigidbody;
    
    private void Awake()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        _reachRadiusSqr = GetComponent<Collider>().bounds.extents.z;
        _reachRadiusSqr *= _reachRadiusSqr;
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

        Vector3 direction = _destination.position - transform.position;
        
        if (direction.sqrMagnitude <= _reachRadiusSqr)
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
