using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private PlayerAnimator _playerAnimator;
    [SerializeField] private InputReader _inputMaster;
    [SerializeField] private Fliper _fliper;

    private float _speed = 8;

    private void OnEnable()
    {
        _inputMaster.HorizontalButtonsPressed += Move;
        _inputMaster.HorizontalButtonsHolding += Move;
        _inputMaster.HorizontalButtonsReleased += Idle;
    }

    private void OnDisable()
    {
        _inputMaster.HorizontalButtonsPressed -= Move;
        _inputMaster.HorizontalButtonsHolding -= Move;
        _inputMaster.HorizontalButtonsReleased -= Idle;
    }

    private void Move(float direction)
    {
        _playerAnimator.Move(true);
        _fliper.Flip(direction);
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }

    private void Idle()
    {
        _playerAnimator.Move(false);
    }
}
