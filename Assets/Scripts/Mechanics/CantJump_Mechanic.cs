using Cinemachine;
using UnityEngine;

public class CantJump_Mechanic : Mechanic
{
    public GameObject _enableRotation;
    public GameObject _disableRotation;

    public override void Enable()
    {
        Debug.Log("EnableMechanic");
        _disableRotation.gameObject.SetActive(true);
        _enableRotation.gameObject.SetActive(false);
    }
    public override void Disable()
    {
        Debug.Log("DisableMechanic");
        _disableRotation.gameObject.SetActive(false);
        _enableRotation.gameObject.SetActive(true);
    }
}
