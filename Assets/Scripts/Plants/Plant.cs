using UnityEngine;

public class Plant : MonoBehaviour
{
  [HideInInspector] public int CurrentHealth;
  protected int MaxHealth;
  protected float Fill = 1f;
  
  protected void Die()
  {
    Destroy(gameObject);
  }
}
