using UnityEngine;

public class MechanicManager : MonoBehaviour
{
    [SerializeField] private Mechanic[] mechanics;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            if (HalfScreen_Mechanic.isHalfScreen)
                mechanics[0].Disable();
            else
                mechanics[0].Enable();
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            if (PlayerMovement.invertedMovement)
                mechanics[1].Disable();
            else
                mechanics[1].Enable();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            //mechanics[2].Enable();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (PlayerMovement.enableJump)
                mechanics[3].Enable();
            else
                mechanics[3].Disable();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
           // mechanics[4].Enable();
        }
    }
}
