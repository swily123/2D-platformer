using UnityEngine;

public class PlayerJumper : MonoBehaviour
{
    [SerializeField] private Jumper _jumper;
    [SerializeField] private InputReader _inputMaster;
    [SerializeField] private PlayerAnimator _playerAnimator;

    private float _jumpForce = 20;
    private bool _isGrounded;

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
            _jumper.Jump(_jumpForce);
            _playerAnimator.SetOrientation(_isGrounded);
            _playerAnimator.Jump();
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
