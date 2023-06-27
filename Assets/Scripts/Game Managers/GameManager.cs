using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
  public static int sunPoints = 50;
  public Text sunPointsText;
  public GameObject prefabSunFlower; 
  public  GameObject prefabPeashooter;
  public GameObject prefabWallNut;
  public static GameObject selectedPrefab;
  public static int indexPrefab;
  public GameObject gameWinPanel;
  public static int countZombies;


  public void WallNutPrefab()
  {
      selectedPrefab = prefabWallNut;
      indexPrefab = 3;
  }
  public void SunFlowerPrefab()
  { 
      selectedPrefab = prefabSunFlower;
      indexPrefab = 1;
  }
  
  public void PeashooterPrefab()
  {
      if (sunPoints >= 100)
      {
          selectedPrefab = prefabPeashooter;
          indexPrefab = 2;
      }
    
  }
  private void Update()
  {
      if (SpawnZombies.low)
      {
          if (countZombies == 22)
          {
              WinGame();
          }
      }
      else if (SpawnZombies.norm)
      {
          if (countZombies == 38)
          {
              WinGame();
          }
      }
      else if (SpawnZombies.hard)
      {
          if (countZombies == 57)
          {
              WinGame();
          }
      }
      sunPointsText.text = sunPoints.ToString();
      
      if (Input.GetKeyDown(KeyCode.Escape))
      {
          selectedPrefab = null;
      }
  }
  private void WinGame()
  {
      Time.timeScale = 0f; 
      gameWinPanel.SetActive(true);
      
  }
}
