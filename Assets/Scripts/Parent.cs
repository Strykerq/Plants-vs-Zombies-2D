using UnityEngine;

public class Parent : MonoBehaviour
{
    public Transform parent;

    private void Update()
    {
        if (Bullet.instance != null)
        {
            Bullet.instance.transform.SetParent(parent.transform);
        }

        if (SunFlowerLogic.instance != null)
        {
            SunFlowerLogic.instance.transform.SetParent(parent.transform);
        }

        if (RandomSpawn.instance != null)
        {
            RandomSpawn.instance.transform.SetParent(parent.transform);
        }

        if (SpawnZombies.instance != null)
        {
            SpawnZombies.instance.transform.SetParent(parent.transform);
        }

        if (SpawnLogic.instance != null)
        {
            SpawnLogic.instance.transform.SetParent(parent.transform);
        }
        
    }
}
