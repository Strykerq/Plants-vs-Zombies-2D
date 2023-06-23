using UnityEngine;
using UnityEngine.UI;

public class ZombieWithDerConeHealthBar : MonoBehaviour
{
    public Image bar;
    public Image fullBar;
    private float fill = 1f;
    private int zombiesWithRedConeHealth = 10;
    private int zombiesWithTedConeMaxHealth = 10;
    private void Update()
    {
        bar.fillAmount = fill;
        if (zombiesWithRedConeHealth == zombiesWithTedConeMaxHealth)
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
    
    public void TakeDamageByZombiesWithRedCone(int damage)
    {
        zombiesWithRedConeHealth -= damage;
        fill -= 0.1f;
        if (zombiesWithRedConeHealth <= 0)
        {
            Destroy(gameObject);
            GameManager.countZombies++;
        }
    }
}
