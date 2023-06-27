using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ArmouredZombie : MonoBehaviour
{
    [SerializeField] private ZombieSettings zombieSettings;

    private float speed;
    private Vector2 movement;
    private bool eating;
    private float fill = 1f;
    public Image bar;
    public Image fullBar;
    private int armouredZombieHealth = 15;
    private int armouredZombieaxHealth = 15;


    private void Start()
    { 
        speed = zombieSettings.zombieSpeed;
        movement = new Vector2(-1f, 0f);
    }
    
    private void Update()
    {
        
        if (eating == false)
        {
            transform.Translate(movement * speed * Time.deltaTime);
        }
        
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
    
    private IEnumerator OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "WallNut")
        {
            eating = true;
            WallNut wallNut = col.gameObject.GetComponent<WallNut>();

            for (int i = -20; i < wallNut.currentHealth; i++)
            {
                wallNut.TakeDamage(1);
                yield return new WaitForSeconds(1f);  
            }

            eating = false;
        }
        
        if (col.gameObject.tag == "Peashooter")
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
