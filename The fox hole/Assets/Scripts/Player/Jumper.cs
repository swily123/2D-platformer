using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Jumper : MonoBehaviour
{
    [SerializeField] private InputMaster _inputMaster;
    [SerializeField] private PlayerAnimator _playerAnimator;

    private Rigidbody2D _rigidbody;
    private bool _isGrounded;
    private float _jumpForce = 20;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _inputMaster.JumpButtonPressed += Jump;
    }

    private void OnDisable()
    {
        _inputMaster.JumpButtonPressed -= Jump;
    }

    private void Jump()
    {
        if (_isGrounded)
        {
            _isGrounded = false;
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _playerAnimator.SetOrientation(_isGrounded);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent<Ground>(out _))
        {
            _isGrounded = true;
            _playerAnimator.SetOrientation(_isGrounded);
        }
    }
}
