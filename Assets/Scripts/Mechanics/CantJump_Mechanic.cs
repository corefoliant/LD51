using UnityEngine;

public class CantJump_Mechanic : Mechanic
{
    public override void Enable()
    {
        Debug.Log("EnableMechanic");
        PlayerMovement.enableJump = true;
    }
    public override void Disable()
    {
        Debug.Log("DisableMechanic");
        PlayerMovement.enableJump = false;
    }
}
