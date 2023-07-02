using UnityEngine;
using UnityEngine.UI;
public class ButtonManager : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Button _button1;
    [SerializeField] private Button _button2;
    private void Update()
    {
        if (GameManager.SunPoints < 50)
        {
            InactiveButton();
        }
        else if (GameManager.SunPoints >= 50)
        {
            ActiveButton();
        }
        if (GameManager.SunPoints < 100)
        {
            InactiveButton1();
        }
        else if (GameManager.SunPoints >= 100)
        {
            ActiveButton1();
        }
        if (GameManager.SunPoints < 125)
        {
            InactiveButton2();
        }
        else if (GameManager.SunPoints >= 125)
        {
            ActiveButton2();
        }
    }
    private void ActiveButton()
    {
        _button.interactable = true;
        _button.GetComponent<Image>().color = Color.white;
    }

    private void InactiveButton()
    {
        _button.interactable = false;
        _button.GetComponent<Image>().color = Color.gray;
    }
    private void ActiveButton1()
    {
        _button1.interactable = true;
        _button1.GetComponent<Image>().color = Color.white;
    }

    private void InactiveButton1()
    {
        _button1.interactable = false;
        _button1.GetComponent<Image>().color = Color.gray;
    }
    private void ActiveButton2()
    {
        _button2.interactable = true;
        _button2.GetComponent<Image>().color = Color.white;
    }

    private void InactiveButton2()
    {
        _button2.interactable = false;
        _button2.GetComponent<Image>().color = Color.gray;
    }
}
