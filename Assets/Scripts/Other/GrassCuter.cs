using UnityEngine;
public class GrassCuter : MonoBehaviour
{
  private float _speed = 1.5f;
  private float _delay = 12f;
  private Vector2 _movement;
  private bool _grassCuter = true;
  private int _zombieLayer = 3;
  
  private void Start()
  {
      _movement = new Vector2(1f, 0f);
  }

  private void Update()
  {
    if (_grassCuter == false)
    {
        transform.Translate(_movement * _speed * Time.deltaTime);
        Destroy(gameObject,_delay);
    }
  }
  private void OnCollisionEnter2D(Collision2D col)
  {
      _grassCuter = false;
      if (col.gameObject.layer == _zombieLayer)
      {
          Destroy(col.gameObject);
      }
  }
}
