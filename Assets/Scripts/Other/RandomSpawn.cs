using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject prefab;
    public static GameObject instance;
    private int minSpawnDelay = 20;
    private int maxSpawnDelay = 90;
    private float randomSpawnPoint;
    private Vector2 spawnPoint;

    private void Start()
    {
        Invoke("Spawn", RandomDelay());
    }

    private void Spawn()
    {
        randomSpawnPoint = Random.Range(-4, 5);
        spawnPoint = new Vector2(randomSpawnPoint, transform.position.y);
        instance = Instantiate(prefab, spawnPoint, Quaternion.identity);

        Invoke("Spawn", RandomDelay());
    }

    private int RandomDelay()
    {
        return Random.Range(minSpawnDelay, maxSpawnDelay);
    }

}