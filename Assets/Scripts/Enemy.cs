using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 2f;
    
    private Mover _mover;
    
    private void Awake()
    {
        _mover = GetComponent<Mover>();
    }

    public void Initialize(Vector3 direction)
    {
        _mover.SetupMovement(direction, _moveSpeed);
    }
}
