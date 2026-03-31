using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    [Header("Prefabs to spawn")]
    public GameObject[] prefabs;  

    [Header("Player reference")]
    public Transform player;     

    [Header("Spawn Settings")]
    public float spawnInterval = 2f;   // Time in seconds between spawns
    public float spawnZDistance = 50f; // Distance ahead of the player to spawn objects
    public float xMin = -5f;           
    public float xMax = 5f;          

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
        if (prefabs.Length == 0 || player == null) return;

       
        int index = Random.Range(0, prefabs.Length);// Randomly select a prefab from the array
        GameObject prefab = prefabs[index];

        
        float randomX = Random.Range(xMin, xMax);

      
        Vector3 spawnPos = new Vector3(randomX, prefab.transform.position.y, player.position.z + spawnZDistance);

       
        Instantiate(prefab, spawnPos, prefab.transform.rotation);
    }
}