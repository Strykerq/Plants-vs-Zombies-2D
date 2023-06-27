using UnityEngine;
using UnityEngine.UI;

public class PeashooterLogic : MonoBehaviour
{
    private int maxHealth = 7;
    private int currentHealth = 7;
    private float fill = 1f;
    public Image bar;
    public Image fullBar;
   
    public void Update()
    {    bar.fillAmount = fill;

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

        if (currentHealth == 0)
        {
           
            Die();
        }
       
        
        
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        fill -= 0.14f;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}
