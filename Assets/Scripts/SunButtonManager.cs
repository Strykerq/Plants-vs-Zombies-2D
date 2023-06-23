using UnityEngine;
using UnityEngine.UI;

public class SunButtonManager : MonoBehaviour
{
    public Button button;

    private void Update()
    {
        if (GameManager.sunPoints < 50)
        {
            InactiveButton();
        }
        else if (GameManager.sunPoints >= 50)
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
