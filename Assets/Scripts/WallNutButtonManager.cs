using UnityEngine;
using UnityEngine.UI;

public class WallNutButtonManager : MonoBehaviour
{
    public Button button;
    private void Update()
    {
        if (GameManager.sunPoints < 125)
        {
            InactiveButton();
        }
        else if (GameManager.sunPoints >= 125)
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
