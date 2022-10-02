using UnityEngine;

public class InvertedMovement_Mechanic : Mechanic
{
    public override void Enable()
    {
        Debug.Log("EnableMechanic");
        PlayerMovement.invertedMovement = true;
    }
    public override void Disable()
    {
        Debug.Log("DisableMechanic");
        PlayerMovement.invertedMovement = false;
    }
}
