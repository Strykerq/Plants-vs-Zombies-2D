using UnityEngine;
public class Bullet : MonoBehaviour
{
    [SerializeField] private ShootingSettings _shootingSettings;
    [SerializeField] private GameObject _bullet;
    public static GameObject Instance;
    [SerializeField] private LayerMask _layerMask;
    RaycastHit2D hit;
    public static float Distance = 10f;
    private bool _zombieDetected;
    private float _timer = 0f;
    private float _shotFrequency;
    private Vector2 _newPosition;
    private void Start()
    {
        _newPosition = transform.position + (transform.right * 1);
    }
    private void Update()
    {
        _shotFrequency = _shootingSettings.shotFrequency;
        if (_zombieDetected)
        {
            _timer += Time.deltaTime;
            if (_timer >= _shotFrequency)
            {
                Shoot();
                _timer = 0f;
            } 
        }
        hit = Physics2D.Raycast(transform.position, Vector2.left, ~_layerMask);
        if (hit.collider!= null)                                                                                    
        {   
            _zombieDetected = true;
            Debug.DrawRay(transform.position,Vector2.right * Distance,Color.red);
        }
        else
        { 
            _zombieDetected = false;
            Debug.DrawRay(transform.position,Vector2.right * Distance,Color.yellow);
        }
    }
    private void Shoot()
    {
        Instance = Instantiate(_bullet,_newPosition, Quaternion.identity);
    }
}
