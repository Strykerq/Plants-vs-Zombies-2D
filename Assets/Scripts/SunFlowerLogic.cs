using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class SunFlowerLogic : MonoBehaviour
{
    public GameObject prefab;
    public static GameObject instance;
    private float force = 0.5f;
    
    public void Start()
    {
        StartCoroutine(SpawnSun());
    }

    IEnumerator SpawnSun()
    {
        while (true)
        {
            yield return new WaitForSeconds(7);
            instance = Instantiate(prefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            Vector2 impulse = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1));
            rb.AddForce(impulse * force, ForceMode2D.Impulse);
        }
    }
} 