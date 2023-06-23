using UnityEngine;

public class GameOver : MonoBehaviour
{
    [HideInInspector]public GrassCuter grassCuter;
    public GameObject gameOverMenu;
    public int zombieLayer = 3;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == zombieLayer)
        {
            EndGame();
        }
        
    }
    private void EndGame()
    {
        Time.timeScale = 0f;
        gameOverMenu.SetActive(true);
    }
}
