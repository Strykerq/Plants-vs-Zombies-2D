using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class DefaultZombiesAI : Zombie
{
    [SerializeField] private Image _bar;
    [SerializeField] private Image _fullBar;
    protected new void Start()
    {
        CurrentHealth = 5;
        MaxHealth = 5;
        base.Start();
    }
    
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        Fill -= 0.2f;
    }
    protected new void Update()
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
    protected override IEnumerator OnCollisionEnter2D(Collision2D col)
    {
        yield return StartCoroutine(base.OnCollisionEnter2D(col));
    }
}
