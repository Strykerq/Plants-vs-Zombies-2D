using UnityEngine;
using UnityEngine.EventSystems;

public class SunDrop : MonoBehaviour,IPointerDownHandler
{
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("Farm",20f);
        Invoke("Stop",10f);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        GameManager.sunPoints += 25;
        Destroy(gameObject);
    }
    private void Farm()
    {
        GameManager.sunPoints += 25;
        Destroy(gameObject);
    }
    private void Stop()
    {
        rb.Sleep();
        rb.isKinematic = true;
    }
}
