using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class ZombieWithRedCone : Zombie
{
    [SerializeField] private Image _bar;
    [SerializeField] private Image _fullBar;
    private new void Start()
    {
        CurrentHealth = 10;
        MaxHealth = 10;
        base.Start();
    }
    private new void Update()
    {
        base.Update();
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
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        Fill -= 0.1f;
    }
    protected override IEnumerator OnCollisionEnter2D(Collision2D col)
    {
        yield return StartCoroutine(base.OnCollisionEnter2D(col));
    }
}
