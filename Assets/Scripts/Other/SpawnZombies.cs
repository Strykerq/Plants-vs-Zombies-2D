using System.Collections;
using UnityEngine;

public class SpawnZombies : MonoBehaviour
{ 
    [SerializeField] private GameObject _defaultZombie;
    [SerializeField] private GameObject _zombieWithRedCone;
    [SerializeField] private GameObject _armouredZombie;
    [SerializeField] private GameObject _healthBar;
    [SerializeField] private Transform[] _spawnPoints;
    private Transform _spawnPosition;
    public static GameObject Instance;
    private int _random;
    public static bool Low;
    public static bool Hard;
    public static bool Norm;

    private void Start()
    {
        StartCoroutine(Wave1());
        if (SliderController.SelectedLevel == SliderController.Low)
        {
            Low = true;
        }
        else if (SliderController.SelectedLevel == SliderController.Normal)
        {
            Norm = true;
        }
        else
        {
            Hard = true;
        }

    }

    private void RandomSpawnPoint()
    {
        _random = Random.Range(0, _spawnPoints.Length);
        _spawnPosition = _spawnPoints[_random];
    }

    private void SpawnDefaultZombie()
    {
        Instance = Instantiate(_defaultZombie, _spawnPosition.position, Quaternion.identity);
    }

    private void SpawnZombieWithRedCone()
    {
        Instance = Instantiate(_zombieWithRedCone, _spawnPosition.position, Quaternion.identity);
    }

    private void SpawnArmouredZombie()
    {
        Instance = Instantiate(_armouredZombie, _spawnPosition.position, Quaternion.identity);
    }

    IEnumerator Wave1()
    {
        yield return new WaitForSeconds(25f);

        for (int i = 0; i < 4; i++)
        {
            RandomSpawnPoint();
            SpawnDefaultZombie();
            yield return new WaitForSeconds(25f);
        }

        RandomSpawnPoint();
        SpawnZombieWithRedCone();
        yield return new WaitForSeconds(3f);
        RandomSpawnPoint();
        SpawnZombieWithRedCone();
        yield return new WaitForSeconds(3f);
        yield return StartCoroutine(Wave2());
        StopCoroutine(Wave1());

    }
    IEnumerator Wave2()
    {
        Debug.Log("WAVE2");
        for (int i = 0; i < 7; i++)
        {
            RandomSpawnPoint();
            SpawnDefaultZombie();
            yield return new WaitForSeconds(3f);
        }

        for (int i = 0; i < 3; i++)
        {
            RandomSpawnPoint();
            SpawnZombieWithRedCone();
            yield return new WaitForSeconds(3f);
        }

        for (int i = 0; i < 4; i++)
        {
            RandomSpawnPoint();
            SpawnDefaultZombie();
            yield return new WaitForSeconds(3f);
        }

        RandomSpawnPoint();
        SpawnArmouredZombie();
        RandomSpawnPoint();
        SpawnZombieWithRedCone();
        if (!Low)
        {
            yield return StartCoroutine(Wave3());
        }
        StopCoroutine(Wave2());
    }
    IEnumerator Wave3()
    {
        Debug.Log("WAVE3");
        yield return new WaitForSeconds(6);
        RandomSpawnPoint();
        SpawnArmouredZombie();
        for (int i = 0; i < 2; i++)
        {
            RandomSpawnPoint();
            SpawnZombieWithRedCone();
            yield return new WaitForSeconds(2);
        }

        for (int i = 0; i < 7; i++)
        {
            RandomSpawnPoint();
            SpawnDefaultZombie();
            yield return new WaitForSeconds(2);
        }

        for (int j = 0; j < 3; j++)
        {
            RandomSpawnPoint();
            SpawnArmouredZombie();
            yield return new WaitForSeconds(2);
        }

        for (int i = 0; i < 4; i++)
        {
            RandomSpawnPoint();
            SpawnZombieWithRedCone();
        }
        if (Hard)
        {
            yield return StartCoroutine(Wave4());
        }
        StopCoroutine(Wave3());
    }
    IEnumerator Wave4()
    {
        for (int i = 0; i < 8; i++)
        {
            RandomSpawnPoint();
            SpawnDefaultZombie();
            yield return new WaitForSeconds(2);
        }

        for (int i = 0; i < 5; i++)
        {
            RandomSpawnPoint();
            SpawnZombieWithRedCone();
            yield return new WaitForSeconds(2);
        }

        for (int i = 0; i < 6; i++)
        {
            RandomSpawnPoint();
            SpawnArmouredZombie();
            yield return new WaitForSeconds(2);
        }
        StopCoroutine(Wave4());
    }
}

