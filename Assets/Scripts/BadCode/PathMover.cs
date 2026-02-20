using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMover : MonoBehaviour
{
    private const float DistanceErrorSqr = 0.001f;
    
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Transform _path;
    
    private Transform[] _wayPoints;
    private Transform _currentDestination;
    private int _wayPointInd;
    
    private void Start()
    {
        _wayPoints = new Transform[_path.childCount];
        
        for (int i = 0; i < _path.childCount; i++)
            _wayPoints[i] = _path.GetChild(i).GetComponent<Transform>();

        _currentDestination = _wayPoints[0];
    }

    private void Update()
    {
        if (_currentDestination == null)
            return;
        
        Vector3 direction = (_currentDestination.position - transform.position).normalized;
        
        transform.Translate(direction * (_moveSpeed * Time.deltaTime));
        
        if (HasReachedDestination())  
            SetNextDestination();
    }

    private void SetNextDestination()
    {
        _wayPointInd = (_wayPointInd + 1) % _wayPoints.Length;
        _currentDestination = _wayPoints[_wayPointInd];
    }

    private bool HasReachedDestination()
    {
        if ((_currentDestination.position - transform.position).sqrMagnitude <= DistanceErrorSqr)
            return true;

        return false;
    }
}