using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverManager : MonoBehaviour
{
   [SerializeField] private GameObject _gameOverMenu;
      
   public void TryAgain()
   {
       _gameOverMenu.SetActive(false);
       GameManager.SunPoints = 50;
       Time.timeScale = 1f;
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }
   public void MainMenu()
   {
       _gameOverMenu.SetActive(false);
       SceneManager.LoadScene(0);
   }
}
