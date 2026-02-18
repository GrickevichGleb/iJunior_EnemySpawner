using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPref;

    public void SpawnEnemy()
    {
        Enemy enemy = Instantiate(_enemyPref, transform.position, transform.rotation);
        
        enemy.Initialize(transform.forward);
    }
}
