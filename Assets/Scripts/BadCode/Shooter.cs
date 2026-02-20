using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Transform Target;

    [SerializeField] private Transform _firingPoint;
    [SerializeField] Rigidbody _projectilePref;
    [SerializeField] public float projectileSpeed;
    [SerializeField] float _shotsInterval;

    private bool _isShooting = true;
    
    private void Start() 
    {
        StartCoroutine(ShootCoroutine());
    }
    
    private IEnumerator ShootCoroutine()
    {
        var delay = new WaitForSeconds(_shotsInterval);
        
        while (_isShooting)
        {
            Vector3 direction = (Target.position - transform.position).normalized;
            
            Rigidbody projectile = Instantiate(_projectilePref, _firingPoint.position, Quaternion.identity);
            
            projectile.transform.up = direction;
            projectile.velocity = direction * projectileSpeed;

            yield return delay;
        }
    }
}