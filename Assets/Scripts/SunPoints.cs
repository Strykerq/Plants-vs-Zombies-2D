using UnityEngine;
using UnityEngine.EventSystems;

public class SunPoints : MonoBehaviour,IPointerDownHandler
{
  private void Start()
  {
      Invoke("Die",9f);
  }
  public void OnPointerDown(PointerEventData eventData)
  {
      GameManager.sunPoints += 25;
      Destroy(gameObject);
  }

  private void Die()
  {
      GameManager.sunPoints += 25;
      Destroy(gameObject);
  }
  
}
