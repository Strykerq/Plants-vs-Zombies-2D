using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;
public class SunFlowerLogic : Plant
{
    [SerializeField] private GameObject _prefab;
    public static GameObject instance;
    private readonly float _force = 0.5f;
    [SerializeField] private Image _bar;
    [SerializeField] private Image _fullBar;
    public void Start()
    {
        StartCoroutine(SpawnSun());
        CurrentHealth = 5;
        MaxHealth = 5;
    }
    private void Update()
    {
        _bar.fillAmount = Fill;

        if (CurrentHealth == MaxHealth)
        {
            _fullBar.enabled = false;
            _bar.enabled = false;
        }
        else
        {
            _fullBar.enabled = true;
            _bar.enabled = true;
        }
    }
    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        Fill -= 0.2f;
        if (CurrentHealth <= 0)
        {
            Die();
        }
    }
    IEnumerator SpawnSun()
    {
        while (true)
        {
            yield return new WaitForSeconds(7);
            instance = Instantiate(_prefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            Vector2 impulse = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1));
            rb.AddForce(impulse * _force, ForceMode2D.Impulse);
        }
    }
} 