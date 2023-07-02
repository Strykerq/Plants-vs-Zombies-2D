using UnityEngine;
public class BulletLogic : MonoBehaviour
{
    private const float SPEED = 5f;
    private void Update()
    {
        Vector2 movement = new Vector2(1f, 0f);
        transform.Translate(movement * SPEED * Time.deltaTime);
    }
    private void OnCollisionEnter2D (Collision2D col)
    {
        Zombie zombie = col.gameObject.GetComponent<Zombie>();
        zombie.TakeDamage(1);
        Destroy(gameObject);
    }
}
