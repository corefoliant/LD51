using UnityEngine;

public class CantJump_Mechanic : Mechanic
{
    public override void Enable()
    {
        Debug.Log("EnableMechanic");
        PlayerMovement.enableJump = false;
    }
    public override void Disable()
    {
        Debug.Log("DisableMechanic");
        PlayerMovement.enableJump = true;
    }
}
