using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ZombieWithRedCone : MonoBehaviour
{
    public Image bar;
    public Image fullBar;
    private float fill = 1f;
    private int zombiesWithRedConeHealth = 10;
    private int zombiesWithTedConeMaxHealth = 10;
    [SerializeField] private ZombieSettings zombieSettings;
    private float speed;
    private Vector2 movement;
    private bool eating;

    
    
    private void Start()
    { 
        speed = zombieSettings.zombieSpeed;
        movement = new Vector2(-1, 0);
    }
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
        
        if (eating == false)
        {
            transform.Translate(movement * speed * Time.deltaTime);
        }
        
    }
    
    public void TakeDamageByZombiesWithRedCone(int damage)
    {
        zombiesWithRedConeHealth -= damage;
        fill -= 0.1f;
        if (zombiesWithRedConeHealth <= 0)
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
    
    
    private IEnumerator OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("WallNut"))
        {
            eating = true;
            WallNut wallNut = col.gameObject.GetComponent<WallNut>();
            for (int i = -20; i < wallNut.maxHealth; i++)
            {
                wallNut.TakeDamage(1);
                yield return new WaitForSeconds(1f);
            }
            
            eating = false;

        }
        
        if (col.gameObject.CompareTag("Peashooter"))
        {
            eating = true;
            PeashooterLogic peashooterLogic = col.gameObject.GetComponent<PeashooterLogic>();
            for (int i = 0; i < 7; i++)           
            {
                peashooterLogic.TakeDamage(1);
                yield return new WaitForSeconds(1);
            }

            eating = false;
        }

        if (col.gameObject.CompareTag("SunFlower"))
        {
            eating = true;
            SunFlowerHealthBar sunFlowerHealthBar = col.gameObject.GetComponent<SunFlowerHealthBar>();
            for (int i = 0; i < 5; i++)
            {
                
                sunFlowerHealthBar.TakeDamage(1);
                yield return new WaitForSeconds(1f);
            }

            eating = false;
        }
    }
}
