using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Text text;
    public Slider slider;
    public static int low = 1;
    public static int normal = 2;
    public static int hard= 3;
    public static int selectedLevel;

    public void Update()
    {
        if (slider.value == 0)
        {
            text.text = "DIFFUCLT : LOW";
            selectedLevel = low;
            Bullet.distance = 3;
        }
        else if (slider.value == 1)
        {
            text.text = "DIFFUCLT : NORMAl";
            selectedLevel = normal;
        }
        else
        {
            text.text = "DIFFUCLT : HARD";
            selectedLevel = hard;
            Bullet.distance = 1;

        }

    }
}
