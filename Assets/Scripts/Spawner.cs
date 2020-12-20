using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float _nextSpawnTime;

    [SerializeField]float _delay = 2f;
    [SerializeField] Transform[] _spawnPoints;
    [SerializeField] Enemy[] _enemies;

    // Update is called once per frame
    void Update()
    {
        if (ShouldSpawn())
            Spawn();
    }

    void Spawn()
    {
        _nextSpawnTime = Time.time + _delay;
        Transform spawnPoint = ChooseSpawnPoint();
        Enemy enemy = ChooseEnemy();
        
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        
    }

    Enemy ChooseEnemy()
    {
        int randomIndex = UnityEngine.Random.Range(0, _enemies.Length);
        
        var enemy = _enemies[randomIndex];
        return enemy;

    }

    Transform ChooseSpawnPoint()
    {
        gameObject.SetActive(true);
        int randomIndex = UnityEngine.Random.Range(0, _spawnPoints.Length);
        var spawnPoint = _spawnPoints[randomIndex];
        return spawnPoint;
    }

    bool ShouldSpawn()
    {
        return Time.time >= _nextSpawnTime;
    }
}
