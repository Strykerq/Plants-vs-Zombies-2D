using UnityEngine;
public class Parent : MonoBehaviour
{   [SerializeField]
    private Transform _parent;
    private void Update()
    {
        if (Bullet.Instance != null)
        {
            Bullet.Instance.transform.SetParent(_parent.transform);
        }

        if (SunFlowerLogic.instance != null)
        {
            SunFlowerLogic.instance.transform.SetParent(_parent.transform);
        }

        if (RandomSpawn.Instance != null)
        {
            RandomSpawn.Instance.transform.SetParent(_parent.transform);
        }

        if (SpawnZombies.Instance != null)
        {
            SpawnZombies.Instance.transform.SetParent(_parent.transform);
        }

        if (SpawnLogic.Instance != null)
        {
            SpawnLogic.Instance.transform.SetParent(_parent.transform);
        }
    }
}
