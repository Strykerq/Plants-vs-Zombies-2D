using UnityEngine;
using UnityEngine.UI;

public class SunFlowerHealthBar : MonoBehaviour
{
    private int maxHealth = 5;
    private int currentHealth;
    private float  fill = 1f;
    public Image bar;
    public Image fullBar;
    public static bool isAlive = true;

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
        fill -= 0.2f;
        if (currentHealth <= 0)
        {
            isAlive = false;
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
    
   
}
