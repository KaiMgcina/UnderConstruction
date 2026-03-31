using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] spawnPrefabs; // Drag your Barrel, Hammer, ToolBox, Collect prefabs here
    public Transform player;           // Player transform
    public float spawnZDistance = 50f; // Distance ahead of the player to spawn
    public float spawnInterval = 2f;   // Seconds between spawns
    public float xMin = -5f;           // Left limit
    public float xMax = 5f;            // Right limit

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnRandomPrefab();
            timer = 0f;
        }
    }

    void SpawnRandomPrefab()
    {
        // Pick random prefab
        int index = Random.Range(0, spawnPrefabs.Length);
        GameObject prefab = spawnPrefabs[index];

        // Random X position
        float randomX = Random.Range(xMin, xMax);

        // Spawn position: ahead of player
        Vector3 spawnPos = new Vector3(randomX, prefab.transform.position.y, player.position.z + spawnZDistance);

        // Instantiate
        Instantiate(prefab, spawnPos, prefab.transform.rotation);
    }
}