using UnityEngine;
using UnityEngine.UI;

public class ArmouredZombieHealthBar : MonoBehaviour
{
    private float fill = 1f;
    public Image bar;
    public Image fullBar;
    private int armouredZombieHealth = 15;
    private int armouredZombieaxHealth = 15;
    private void Update()
    {
        bar.fillAmount = fill;
        if (armouredZombieHealth == armouredZombieaxHealth)
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
    
    public void TakeDamageByArmouredZombie(int damage)
    {
        armouredZombieHealth -= damage;
        fill -= 0.066f;
        if (armouredZombieHealth <= 0)
        {
            Destroy(gameObject);
            GameManager.countZombies++;
        }
    }
}
