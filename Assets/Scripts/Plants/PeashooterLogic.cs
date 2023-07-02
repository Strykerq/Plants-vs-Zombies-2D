using UnityEngine;
using UnityEngine.UI;
public class PeashooterLogic : Plant
{   
    [SerializeField] private Image _bar;
    [SerializeField] private Image _fullBar;
    private void Start()
    {
        CurrentHealth = 7;
        MaxHealth = 7;
    }
    public void Update()
    {    _bar.fillAmount = Fill;

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
        Fill -= 0.14f;
        if (CurrentHealth <= 0)
        {
            Die();
        }
    }
}
