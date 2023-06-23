using System.Collections;
using UnityEngine;

public class ZombieWithRedCone : MonoBehaviour
{
    [SerializeField] private ZombieSettings zombieSettings;
    private float speed;
    public GameObject sun;
    private Vector2 movement;
    private bool eating;
    
    private void Start()
    { 
        speed = zombieSettings.zombieSpeed;
        movement = new Vector2(-1, 0);
    }
    
    private void Update()
    {
        if (eating == false)
        {
            transform.Translate(movement * speed * Time.deltaTime);
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