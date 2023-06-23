using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    private float speed = 5f;
    private void Update()
    {
        Vector2 movement = new Vector2(1f, 0f);
        transform.Translate(movement * speed * Time.deltaTime);
    }
    
    private void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.CompareTag("Zombie"))
        {
            ZombieHealthBar zombieHealthBar = col.gameObject.GetComponent<ZombieHealthBar>();
            zombieHealthBar.TakeDamageByDefaultZombies(1);
            Destroy(gameObject);
        }

        if (col.gameObject.CompareTag("ZombieWithRedCone"))
        {
            ZombieWithDerConeHealthBar zombieWithDerConeHealthBar = col.gameObject.GetComponent<ZombieWithDerConeHealthBar>();
            zombieWithDerConeHealthBar.TakeDamageByZombiesWithRedCone(1);
            Destroy(gameObject);
        }

        if (col.gameObject.CompareTag("ArmouredZomibe"))
        {
            ArmouredZombieHealthBar armouredZombieHealthBar = col.gameObject.GetComponent<ArmouredZombieHealthBar>();
            armouredZombieHealthBar.TakeDamageByArmouredZombie(1);
            Destroy(gameObject);
        }
    }

   
    
}
