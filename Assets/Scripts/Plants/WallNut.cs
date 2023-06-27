using UnityEngine;
using UnityEngine.UI;

public class WallNut : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 20;
    private float fill = 1f;
    public Image bar;
    public Image fullBar;
    
    private void Start()
    {
        currentHealth = maxHealth;
    }
    
    private void Update()
    {
        bar.fillAmount = fill;

        if (currentHealth == maxHealth)
        {
            fullBar.enabled = false;
            bar.enabled = false;
        }
        else
        {
            fullBar.enabled = true;
            bar.enabled = true;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        fill -= 0.05f;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }
}