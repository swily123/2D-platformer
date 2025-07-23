using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action<float> HorizontalButtonsPressed;
    public event Action HorizontalButtonsReleased;
    public event Action<float> HorizontalButtonsHolding;
    public event Action JumpButtonPressed;

    private const string Horizontal = nameof(Horizontal);

    private void Update()
    {
        float direction = Input.GetAxisRaw(Horizontal);

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            HorizontalButtonsPressed?.Invoke(direction);
        }
        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            HorizontalButtonsReleased?.Invoke();
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            HorizontalButtonsHolding?.Invoke(direction);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpButtonPressed?.Invoke();
        }
    }
}