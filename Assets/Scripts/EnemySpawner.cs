using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPref;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _spawnInterval;

    private bool _isSpawning = true;

    private void Start()
    {
        StartCoroutine(SpawningCoroutine(_spawnInterval));
    }

    private IEnumerator SpawningCoroutine(float interval)
    {
        var delay = new WaitForSeconds(interval);

        while (_isSpawning)
        {
            yield return delay;
            
            SpawnEnemy(GetRandomSpawnPoint());
        }
    }

    private void SpawnEnemy(Transform spawnPoint)
    {
        Enemy enemy = Instantiate(_enemyPref, spawnPoint.position, spawnPoint.rotation);
        
        enemy.Initialize(spawnPoint.forward);
    }

    private Transform GetRandomSpawnPoint()
    {
        int index = UtilsRandom.GetRandomNumber(0, _spawnPoints.Length - 1);

        return _spawnPoints[index];
    }
}
