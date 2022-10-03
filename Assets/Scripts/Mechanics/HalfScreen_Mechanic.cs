using UnityEngine;
using UnityEngine.UI;

public class HalfScreen_Mechanic : Mechanic
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private Image[] _sides;
    private int CurSide = -1;
    public static bool isHalfScreen = false;
    
    public override void Enable()
    {
        Debug.Log("EnableMechanic");
        CurSide = Random.Range(0, _sides.Length);
        _sides[CurSide].enabled = true;
        isHalfScreen = true;
    }

    public override void Disable()
    {
        Debug.Log("DisableMechanic");
        _sides[CurSide].enabled = false;
        isHalfScreen = false;
    }
}
