using UnityEngine;
using UnityEngine.UI;

public class HalfScreen_Mechanic : Mechanic
{
    [SerializeField] private Canvas canvas;

    public static bool isHalfScreen = false;

    public override void Enable()
    {
        Debug.Log("EnableMechanic");
        canvas.GetComponentInChildren<Image>().enabled = true;
        isHalfScreen = true;
    }

    public override void Disable()
    {
        Debug.Log("DisableMechanic");
        canvas.GetComponentInChildren<Image>().enabled = false;
        isHalfScreen = false;
    }
}
