using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ZombieHealthBar : MonoBehaviour
{
    public Image bar;
    public Image fullBar;
    private float fill = 1f;
    private int defaultZombieHealth = 5;
    private int defaultZombieMaxHealth = 5;
    

    private void Update()
    {
        bar.fillAmount = fill;

        if (defaultZombieHealth == defaultZombieMaxHealth)
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
    public void TakeDamageByDefaultZombies(int damage)
    {
        defaultZombieHealth -= damage;
        fill -= 0.2f;
        if (defaultZombieHealth <= 0)
        {
            Die();
        }
    }
    
    private void Die()
    {
        int randomIndex = Random.Range(0, 5);
        if (randomIndex == 1)
        {
            GameManager.sunPoints += 25;
        }
        Destroy(gameObject);
        GameManager.countZombies++;
    }
    
    
    
}
