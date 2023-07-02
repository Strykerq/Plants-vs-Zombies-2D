using UnityEngine;
using UnityEngine.EventSystems;

public class SunDrop : MonoBehaviour,IPointerDownHandler
{
    private Rigidbody2D _rb;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Invoke("Farm",20f);
        Invoke("Stop",10f);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        GameManager.SunPoints += 25;
        Destroy(gameObject);
    }
    private void Farm()
    {
        GameManager.SunPoints += 25;
        Destroy(gameObject);
    }
    private void Stop()
    {
        _rb.Sleep();
        _rb.isKinematic = true;
    }
}
