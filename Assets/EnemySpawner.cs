using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    public GameObject[] Enemies; // Array to assign enemy prefabs
    public Transform player; // Reference to the player
    public float spawnRadius = 30f; // Distance from the player to spawn enemies (Changed in unity to 30)
    public float spawnDelay = 1f; // Time between enemy spawns

    [Header("Horde Settings")]
    public int enemiesPerWave = 5; // Number of enemies per wave
    public float timeBetweenWaves = 5f; // Time between each wave
    public int totalWaves = 3; // Total number of waves

    private int currentWave = 0;

    void Start()
    {
        // Initialize enemy array if not set in Inspector (optional)
        if (Enemies == null || Enemies.Length == 0)
        {
            Enemies = new GameObject[3];
            Enemies[0] = Resources.Load<GameObject>("Enemy");
            Enemies[1] = Resources.Load<GameObject>("Enemy 1");
            Enemies[2] = Resources.Load<GameObject>("Enemy 2");
        }

        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        while (currentWave < totalWaves)
        {
            currentWave++;
            for (int i = 0; i < enemiesPerWave; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(spawnDelay); // Delay between enemy spawns
            }
            yield return new WaitForSeconds(timeBetweenWaves); // Delay between waves
        }
    }

    void SpawnEnemy()
    {
        Vector3 spawnPosition = GetRandomSpawnPosition();
        if (spawnPosition != Vector3.zero && Enemies.Length > 0)
        {
            // Select a random enemy prefab from the array
            int randomIndex = Random.Range(0, Enemies.Length);
            GameObject selectedEnemy = Enemies[randomIndex];

            Instantiate(selectedEnemy, spawnPosition, Quaternion.identity);
        }
    }

    Vector3 GetRandomSpawnPosition()
    {
        // Generate a random angle within the player's  field of view
        float angle = Random.Range(-100f, 100f); // -100 to 100 degrees

        // Convert angle to radians and calculate spawn position around the player
        float radians = angle * Mathf.Deg2Rad;
        Vector3 offset = new Vector3(Mathf.Sin(radians), 0, Mathf.Cos(radians)) * spawnRadius;

        Vector3 spawnPosition = player.position + offset;

    

        return spawnPosition;
    }
}
