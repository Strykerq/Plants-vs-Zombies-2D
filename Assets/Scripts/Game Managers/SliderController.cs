using UnityEngine;
using UnityEngine.UI;
public class SliderController : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private Slider _slider;
    public static int Low = 1;
    public static int Normal = 2;
    public static int Hard = 3;
    public static int SelectedLevel;
    public void Update()
    {
        if (_slider.value == 0)
        {
            _text.text = "DIFFUCLT : LOW";
            SelectedLevel = Low;
            Bullet.Distance = 12;
        }
        else if (_slider.value == 1)
        {
            _text.text = "DIFFUCLT : NORMAl";
            SelectedLevel = Normal;
        }
        else
        {
            _text.text = "DIFFUCLT : HARD";
            SelectedLevel = Hard;
            Bullet.Distance = 8;
        }
    }
}
