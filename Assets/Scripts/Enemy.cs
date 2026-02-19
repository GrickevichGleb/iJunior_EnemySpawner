using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private float _rotationSpeed = 120f;
    [SerializeField] private Target _target;
    
    private Mover _mover;
    
    private void Awake()
    {
        _mover = GetComponent<Mover>();
    }

    public void Initialize(Target target)
    {
        _target = target;
        _mover.SetupMover(_moveSpeed, _rotationSpeed);
        _mover.SetDestination(_target.transform);
    }
}
