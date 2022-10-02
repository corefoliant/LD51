using UnityEngine;

public class MinusOneKey_Mechanic : Mechanic
{
    private char[] keys = {'W', 'A', 'S', 'D'};

    public override void Enable()
    {
        int i = Random.Range(0, keys.Length);
        PlayerMovement.minusKey = keys[i];
        Debug.Log($"EnableMechanic -{keys[i]}");
    }

    public override void Disable()
    {
        Debug.Log("DisableMechanic");
        PlayerMovement.minusKey = '-';
    }
}
