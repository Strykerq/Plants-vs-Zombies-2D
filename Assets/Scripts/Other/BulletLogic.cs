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
            DefaultZombiesAI defaultZombiesAI = col.gameObject.GetComponent<DefaultZombiesAI>();
            defaultZombiesAI.TakeDamageByDefaultZombies(1);
            Destroy(gameObject);
        }

        if (col.gameObject.CompareTag("ZombieWithRedCone"))
        {
            ZombieWithRedCone zombieWithRedCone = col.gameObject.GetComponent<ZombieWithRedCone>();
            zombieWithRedCone.TakeDamageByZombiesWithRedCone(1);
            Destroy(gameObject);
        }

        if (col.gameObject.CompareTag("ArmouredZomibe"))
        {
            ArmouredZombie armouredZombie = col.gameObject.GetComponent<ArmouredZombie>();
            armouredZombie.TakeDamageByArmouredZombie(1);
            Destroy(gameObject);
        }
    }

   
    
}
