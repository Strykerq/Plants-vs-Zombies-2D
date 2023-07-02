using UnityEngine;

public class RandomSpawn : MonoBehaviour
{   [SerializeField]
    private GameObject _prefab;
    public static GameObject Instance;
    private int _minSpawnDelay = 20;
    private int _maxSpawnDelay = 90;
    private float _randomSpawnPoint;
    private Vector2 _spawnPoint;

    private void Start()
    {
        Invoke("Spawn", RandomDelay());
    }

    private void Spawn()
    {
        _randomSpawnPoint = Random.Range(-4, 5);
        _spawnPoint = new Vector2(_randomSpawnPoint, transform.position.y);
        Instance = Instantiate(_prefab, _spawnPoint, Quaternion.identity);
        Invoke("Spawn", RandomDelay());
    }
    private int RandomDelay()
    {
        return Random.Range(_minSpawnDelay, _maxSpawnDelay);
    }
}