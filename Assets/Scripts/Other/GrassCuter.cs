using UnityEngine;

public class GrassCuter : MonoBehaviour
{
  private float speed = 1.5f;
  private float delay = 14f;
  private Vector2 movement;
  public bool grassCuter = true;
  public int zombieLayer = 3;
  
  private void Start()
  {
      movement = new Vector2(1f, 0f);
  }

  private void Update()
  {
    if (grassCuter == false)
    {
        transform.Translate(movement * speed * Time.deltaTime);
        Destroy(gameObject,delay);
    }
    
  }
  private void OnCollisionEnter2D(Collision2D col)
  {
      grassCuter = false;
      if (col.gameObject.layer == zombieLayer)
      {
          Destroy(col.gameObject);
      }
  }
}
