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
      GameManager.SunPoints += 25;
      Destroy(gameObject);
  }

  private void Die()
  {
      GameManager.SunPoints += 25;
      Destroy(gameObject);
  }
}
