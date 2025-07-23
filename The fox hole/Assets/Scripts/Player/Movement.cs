using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private PlayerAnimator _playerAnimator;
    [SerializeField] private InputMaster _inputMaster;
    [SerializeField] private Fliper _fliper;

    private const string _horizontal = "Horizontal";
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

    private void Move()
    {
        _playerAnimator.Move(true);
        float direction = Input.GetAxisRaw(_horizontal);
        _fliper.Flip(direction);
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }

    private void Idle()
    {
        _playerAnimator.Move(false);
    }
}
