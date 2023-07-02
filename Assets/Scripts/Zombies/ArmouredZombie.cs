using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class ArmouredZombie : Zombie
{
    [SerializeField] private Image _bar;
    [SerializeField] private Image _fullBar;
    private new void Start()
    {
        base.Start();
        CurrentHealth = 15;
        MaxHealth = 15;
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
        Fill -= 0.066f;
    }
    protected override IEnumerator OnCollisionEnter2D(Collision2D col)
    {
        yield return StartCoroutine(base.OnCollisionEnter2D(col));
    }
}
