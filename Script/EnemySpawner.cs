using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies; // Array of enemy prefabs to spawn
    [SerializeField] private float timeBetweenSpawns = 2f; // Time interval between spawns
    [SerializeField] private Transform[] spawnPoints; // Array of spawn points
    void Start()
    {
        StartCoroutine(SpawnEnemiesCoroutine());
    }

    private IEnumerator SpawnEnemiesCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenSpawns);
            GameObject enemy = enemies[Random.Range(0, enemies.Length)]; // Randomly select an enemy prefab
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)]; // Randomly select a spawn point
            Instantiate(enemy, spawnPoint.position, spawnPoint.rotation); // Spawn the enemy at the selected spawn point
        }
    }    
}
