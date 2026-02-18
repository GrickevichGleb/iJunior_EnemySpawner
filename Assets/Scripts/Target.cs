using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 6f;
    [SerializeField] private float _rotationSpeed = 80f;
    
    [SerializeField] private Transform[] _path;

    private Mover _mover;
    private int _waypointInd = 0;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
    }

    private void Start()
    {
        _mover.SetupMovement(_path[_waypointInd], _moveSpeed, _rotationSpeed);
    }

    private void Update()
    {
        if (_mover.HasReachedTarget())
        {
            _waypointInd = GetNextWayPointIndex();
            _mover.SetupMovement(_path[_waypointInd], _moveSpeed, _rotationSpeed);
        }
            
    }

    private int GetNextWayPointIndex()
    {
        return (_waypointInd + 1) % _path.Length;
    }

    
}
