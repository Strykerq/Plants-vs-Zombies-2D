using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
   public GameObject gameOverMenu;
      
   public void TryAgain()
   {
       gameOverMenu.SetActive(false);
       GameManager.sunPoints = 100;
       Time.timeScale = 1f;
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }

   public void MainMenu()
   {
       gameOverMenu.SetActive(false);
       SceneManager.LoadScene(0);
   }
}
