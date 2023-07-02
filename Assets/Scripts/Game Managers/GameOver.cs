using UnityEngine;
public class GameOver : MonoBehaviour
{
    [SerializeField] private  GameObject _gameOverMenu;
    private GrassCuter _grassCuter;
    private int _zombieLayer = 3;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == _zombieLayer)
        {
            EndGame();
        }
    }
    private void EndGame()
    {
        Time.timeScale = 0f;
        _gameOverMenu.SetActive(true);
    }
}
