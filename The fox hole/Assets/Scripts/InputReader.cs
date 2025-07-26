using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action<float> HorizontalButtonsPressed;
    public event Action<float> HorizontalButtonsHolding;
    public event Action HorizontalButtonsReleased;
    public event Action JumpButtonPressed;
    public event Action LeftButtonClicked;
    public event Action AbilityPressed;

    private const string Horizontal = nameof(Horizontal);
    private const KeyCode LeftMovement = KeyCode.A;
    private const KeyCode RightMovement = KeyCode.D;
    private const KeyCode Jump = KeyCode.Space;
    private const KeyCode Ability = KeyCode.E;

    private void Update()
    {
        float direction = Input.GetAxisRaw(Horizontal);

        if (Input.GetKeyDown(LeftMovement) || Input.GetKeyDown(RightMovement))
        {
            HorizontalButtonsPressed?.Invoke(direction);
        }
        else if (Input.GetKeyUp(LeftMovement) || Input.GetKeyUp(RightMovement))
        {
            HorizontalButtonsReleased?.Invoke();
        }
        else if (Input.GetKey(LeftMovement) || Input.GetKey(RightMovement))
        {
            HorizontalButtonsHolding?.Invoke(direction);
        }

        if (Input.GetKeyDown(Jump))
        {
            JumpButtonPressed?.Invoke();
        }

        if (Input.GetMouseButtonDown(0))
        {
            LeftButtonClicked?.Invoke();
        }

        if (Input.GetKeyDown(Ability))
        {
            AbilityPressed?.Invoke();
        }
    }
}