using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
  public static int SunPoints = 50;
  [SerializeField] private Text _sunPointsText;
  [SerializeField] private GameObject _prefabSunFlower; 
  [SerializeField] private GameObject _prefabPeashooter;
  [SerializeField] private GameObject _prefabWallNut;
  [SerializeField] GameObject _gameWinPanel;
  public static GameObject SelectedPrefab;
  public static int IndexPrefab;
  public static int CountZombies;
  public void WallNutPrefab()
  {
      SelectedPrefab = _prefabWallNut;
      IndexPrefab = 3;
  }
  public void SunFlowerPrefab()
  { 
      SelectedPrefab = _prefabSunFlower;
      IndexPrefab = 1;
  }
  public void PeashooterPrefab()
  {
      if (SunPoints >= 100)
      {
          SelectedPrefab = _prefabPeashooter;
          IndexPrefab = 2;
      }
  }
  private void Update()
  {
      if (SpawnZombies.Low)
      {
          if (CountZombies == 22)
          {
              WinGame();
          }
      }
      else if (SpawnZombies.Norm)
      {
          if (CountZombies == 38)
          {
              WinGame();
          }
      }
      else if (SpawnZombies.Hard)
      {
          if (CountZombies == 58)
          {
              WinGame();
          }
      }
      _sunPointsText.text = SunPoints.ToString();
      
      if (Input.GetKeyDown(KeyCode.Escape))
      {
          SelectedPrefab = null;
      }
  }
  private void WinGame()
  {
      Time.timeScale = 0f; 
      _gameWinPanel.SetActive(true);
  }
}
