using UnityEngine;

public class MechanicManager : MonoBehaviour
{
    [SerializeField] private Mechanic[] mechanics;

    private void Start()
    {
        for (int i = 0; i < mechanics.Length; i++)
        {
            mechanics[i].Disable();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            if (HalfScreen_Mechanic.isHalfScreen)
                mechanics[0].Disable();
            else{
                mechanics[0].Enable();
                mechanics[1].Disable();
                mechanics[2].Disable();
                mechanics[3].Disable();}
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            if (PlayerMovement.invertedMovement)
                mechanics[1].Disable();
            else{
                mechanics[1].Enable();
                mechanics[0].Disable();
                mechanics[2].Disable();
                mechanics[3].Disable();}
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (PlayerMovement.minusKey == '-'){
                mechanics[2].Enable();
                mechanics[0].Disable();
                mechanics[1].Disable();
                mechanics[3].Disable();}
            else
                mechanics[2].Disable();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (PlayerMovement.enableJump){
                mechanics[3].Enable();
                mechanics[0].Disable();
                mechanics[1].Disable();
                mechanics[2].Disable();}
            else
                mechanics[3].Disable();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
           // mechanics[4].Enable();
        }
    }
}
