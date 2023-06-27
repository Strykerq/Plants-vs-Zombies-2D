using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private ShootingSettings shootingSettings;

    public GameObject bullet;
    public static GameObject instance;
    private Vector2 newPosition;
    RaycastHit2D hit;
    public LayerMask layerMask;
    public static float distance = 3f;
    private bool zombieDetected;
    private float timer = 0f;
    private float shotFrequency;
    
    private void Start()
    {
        newPosition = transform.position + (transform.right * 1);
        
    }
    

    private void Update()
    {
        shotFrequency = shootingSettings.shotFrequency;
         
        if (zombieDetected)
        {
            timer += Time.deltaTime;
            if (timer >= shotFrequency)
            {
                Shoot();
                timer = 0f;
            } 
        }
        
        hit = Physics2D.Raycast(transform.position, Vector2.left * distance, ~layerMask);
        
         
        if (hit.collider!= null)                                                                                    
        {   
            zombieDetected = true;
            Debug.DrawRay(transform.position,Vector2.right * distance,Color.black);
                    
        }
        else
        { 
            zombieDetected = false;
            Debug.DrawRay(transform.position,Vector2.right * distance,Color.black);
                     
        }

        
    }

    public void Shoot()
    {
        instance = Instantiate(bullet,newPosition, Quaternion.identity);
    }
}
