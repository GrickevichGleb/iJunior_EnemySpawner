using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    [SerializeField] private float _destroyAfter = 10f;
    
    private void Start()
    {
        Destroy(gameObject, _destroyAfter);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out Enemy _))
        {
            Destroy(gameObject);
        }
    }
}
