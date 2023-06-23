using System.Collections;
using UnityEngine;

public class SpawnZombies : MonoBehaviour
{
    public GameObject defaultZombie;
    public GameObject zombieWithRedCone;
    public GameObject armouredZombie;
    public GameObject HealthBar;
    public Transform[] spawnPoints;
    public static ZombieHealthBar zombieHealth;
    private Transform spawnPosition;
    public static GameObject instance;
    private int random;
    public static bool low;
    public static bool hard;
    public static bool norm;
    private int zombie;
    private int Arzombie;
    private int Conzombie;

    private void Start()
    {
        StartCoroutine(Wave1());
        if (SliderController.selectedLevel == SliderController.low)
        {
            low = true;
        }
        else if (SliderController.selectedLevel == SliderController.normal)
        {
            norm = true;
        }
        else
        {
            hard = true;
        }

    }

    private void RandomSpawnPoint()
    {
        random = Random.Range(0, spawnPoints.Length);
        spawnPosition = spawnPoints[random];
    }

    private void SpawnDefaultZombie()
    {
        instance = Instantiate(defaultZombie, spawnPosition.position, Quaternion.identity);
        zombie++;



    }

    private void SpawnZombieWithRedCone()
    {
        instance = Instantiate(zombieWithRedCone, spawnPosition.position, Quaternion.identity);
        Conzombie++;
    }

    private void SpawnArmouredZombie()
    {
        instance = Instantiate(armouredZombie, spawnPosition.position, Quaternion.identity);
        Arzombie++;
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
        if (!low)
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

        Debug.Log("Arzombie" + Arzombie);
        Debug.Log("Zombie " + zombie);
        Debug.Log(("Conzombie " + Conzombie));
        if (hard)
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

