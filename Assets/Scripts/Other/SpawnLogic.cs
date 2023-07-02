using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpawnLogic : MonoBehaviour, IPointerDownHandler
{
    public static GameObject Instance;
   [SerializeField]
   private Transform _parent;
   private GameObject _selectedPrefab;
   private bool _isEmpty = true;
   private int _cost;
   private Image _image;
   private void Start()
   {
      _image = GetComponent<Image>();
   }
   private void Update()
   {
       if (GameManager.SelectedPrefab == null && _image != null)               // 
       {                                                                      //
           _image.raycastTarget = false;                                        //
       }                                                                      //   THIS IS TO SOLVE A CONFLICT BETWEEN TWO (ON POINTER DOWN)
       else if(GameManager.SelectedPrefab != null && _image != null)           //    
       {                                                                      //
           _image.raycastTarget = true;                                         //
       }                                                                       
       _selectedPrefab = GameManager.SelectedPrefab; 
      
       if (GameManager.IndexPrefab == 1)
       {
           _cost = 50;
       }
       else if(GameManager.IndexPrefab == 2)
       {
           _cost = 100;
       }
       else
       {
          _cost = 125;
       }

       if (Instance == null)
       {
           _isEmpty = true;
       }
   }
   public void OnPointerDown(PointerEventData eventData)
   {
       if (GameManager.SelectedPrefab != null)
       {
           if (_isEmpty && GameManager.SunPoints >= _cost)
           {
               Instance = Instantiate(_selectedPrefab, transform.position, Quaternion.identity,_parent);
               if (GameManager.IndexPrefab == 1)
               {
                   SunFlowerLogic sunFlowerHealthBar = Instance.GetComponent<SunFlowerLogic>();
               }

               if (GameManager.IndexPrefab == 2)
               {
                   PeashooterLogic peashooterLogic = Instance.GetComponent<PeashooterLogic>();
               }
            
               if (GameManager.IndexPrefab == 3)
               {
                   WallNut wallNut = Instance.GetComponent<WallNut>();
               }
            
               GameManager.SunPoints -= _cost;
               GameManager.SelectedPrefab = null;
               _isEmpty = false;
           }
       }
   }
}
