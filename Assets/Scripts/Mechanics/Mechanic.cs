using UnityEngine;

public class Mechanic : MonoBehaviour
{
    public virtual void Enable()
    {
        Debug.Log("EnableMechanic");
    }

    public virtual void Disable()
    {
        Debug.Log("DisableMechanic");
    }
}
