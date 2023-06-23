using UnityEngine;
using UnityEngine.UI;

public class PeashooterButtonManager : MonoBehaviour
{
    public Button button;
    private void Update()
    {
        if (GameManager.sunPoints < 100)
        {
            InactiveButton();
        }
        else if (GameManager.sunPoints >= 100)
        {
            ActiveButton();
        }
    }

    private void ActiveButton()
    {
        button.interactable = true;
        button.GetComponent<Image>().color = Color.white;
    }

    private void InactiveButton()
    {
        button.interactable = false;
        button.GetComponent<Image>().color = Color.gray;
    }
}
