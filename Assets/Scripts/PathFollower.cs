using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Mover))]
public class PathFollower : MonoBehaviour
{
    [SerializeField] private GameObject _path;

    private Mover _mover;
    private WayPoint[] _wayPoints;
    private int _waypointInd = 0;
    
    private void Awake()
    {
        _mover = GetComponent<Mover>();
    }
    
    private void Start()
    {
        _wayPoints = _path.GetComponentsInChildren<WayPoint>();
        _mover.SetDestination(_wayPoints[_waypointInd].transform);
    }

    private void Update()
    {
        if (_mover.HasReachedDestination())
        {
            _waypointInd = GetNextWayPointIndex();
            _mover.SetDestination(_wayPoints[_waypointInd].transform);
        }
    }

    private int GetNextWayPointIndex()
    {
        return (_waypointInd + 1) % _wayPoints.Length;
    }
}
