using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;
public class Zombie : MonoBehaviour    
{
  [SerializeField] private ZombieSettings _zombieSettings;
  protected int CurrentHealth;
  protected int MaxHealth;
  protected float Speed;
  protected float Fill = 1f;
  protected bool Eating;
  private Vector2 _movement;

  protected void Start()
  {
    Speed = _zombieSettings.zombieSpeed;
    _movement = new Vector2(-1f, 0f);
  }
  protected void Update()
  {
    if (Eating == false)
    {
      transform.Translate(_movement * Speed * Time.deltaTime);
    }
    
  }
  protected void Die()
  {
    int randomIndex = Random.Range(0, 5);
    if (randomIndex == 1)
    {
      GameManager.SunPoints += 25;
    }
    Destroy(gameObject);
    GameManager.CountZombies++;
  }
  public virtual void TakeDamage(int damage)
  {
    CurrentHealth -= damage;
    if (CurrentHealth <= 0)
    {
      Die();
    }
  }
  protected virtual IEnumerator OnCollisionEnter2D(Collision2D col)
  {
    if (col.gameObject.CompareTag("WallNut"))
    {
      Eating = true;
      WallNut wallNut = col.gameObject.GetComponent<WallNut>();
      if (wallNut != null)
      {
        while (wallNut.CurrentHealth > 0)
        {
          wallNut.TakeDamage(1);
          yield return new WaitForSeconds(1f);
        }
      }
      Eating = false;
    }
    if (col.gameObject.CompareTag("Peashooter"))
    {
      Eating = true;
      PeashooterLogic peashooterLogic = col.gameObject.GetComponent<PeashooterLogic>();
      while (peashooterLogic.CurrentHealth > 0)
      {
        peashooterLogic.TakeDamage(1);
        yield return new WaitForSeconds(1);
      }
      Eating = false;
    }
    if (col.gameObject.CompareTag("SunFlower"))
    {
      Eating = true;
      SunFlowerLogic sunFlower = col.gameObject.GetComponent<SunFlowerLogic>();
      while (sunFlower.CurrentHealth > 0)
      {
        sunFlower.TakeDamage(1);
        yield return new WaitForSeconds(1);
      }
      Eating = false;
    }
  }
}
