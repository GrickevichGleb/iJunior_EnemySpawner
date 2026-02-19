using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private SpawnPoint[] _spawnPoints;
    [SerializeField] private float _spawnInterval;

    private bool _isSpawning = true;

    private void Start()
    {
        StartCoroutine(SpawnCoroutine(_spawnInterval));
    }

    private IEnumerator SpawnCoroutine(float interval)
    {
        var delay = new WaitForSeconds(interval);

        while (_isSpawning)
        {
            yield return delay;
            
            GetRandomSpawnPoint().SpawnEnemy();
        }
    }
    
    private SpawnPoint GetRandomSpawnPoint()
    {
        int index = UtilsRandom.GetRandomNumber(0, _spawnPoints.Length - 1);

        return _spawnPoints[index];
    }
}
