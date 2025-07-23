using System;
using UnityEngine;

public class InputMaster : MonoBehaviour
{
    public event Action HorizontalButtonsPressed;
    public event Action HorizontalButtonsReleased;
    public event Action HorizontalButtonsHolding;
    public event Action JumpButtonPressed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            HorizontalButtonsPressed?.Invoke();
        }
        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            HorizontalButtonsReleased?.Invoke();
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            HorizontalButtonsHolding?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpButtonPressed?.Invoke();
        }
    }
}