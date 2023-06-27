using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpawnLogic : MonoBehaviour, IPointerDownHandler
{
   public static GameObject instance;
   public Transform parent;
   private GameObject selectedPrefab;
   private bool isEmpty = true;
   private int cost;
   private Image image;
   
   private void Start()
   {
      image = GetComponent<Image>();
   }

   private void Update()
   {
       if (GameManager.selectedPrefab == null && image != null)               // 
       {                                                                      //
           image.raycastTarget = false;                                        //
       }                                                                      //   THIS IS TO SOLVE A CONFLICT BETWEEN TWO (ON POINTER DOWN)
       else if(GameManager.selectedPrefab != null && image != null)           //    
       {                                                                      //
           image.raycastTarget = true;                                         //
       }                                                                       
       selectedPrefab = GameManager.selectedPrefab; 
      
       if (GameManager.indexPrefab == 1)
       {
           cost = 50;
       }
       else if(GameManager.indexPrefab == 2)
       {
           cost = 100;
       }
       else
       {
          cost = 125;
       }
   }

   public void OnPointerDown(PointerEventData eventData)
   {
       if (GameManager.selectedPrefab != null)
       {
           if (isEmpty && GameManager.sunPoints >= cost)
           {
               instance = Instantiate(selectedPrefab, transform.position, Quaternion.identity,parent);
               if (GameManager.indexPrefab == 1)
               {
                   SunFlowerHealthBar sunFlowerHealthBar = instance.GetComponent<SunFlowerHealthBar>();
               }

               if (GameManager.indexPrefab == 2)
               {
                   PeashooterLogic peashooterLogic = instance.GetComponent<PeashooterLogic>();
               }
            
               if (GameManager.indexPrefab == 3)
               {
                   WallNut wallNut = instance.GetComponent<WallNut>();
               }
            
               GameManager.sunPoints -= cost;
               GameManager.selectedPrefab = null;
               isEmpty = false;
           }
       }
      
   }
}
