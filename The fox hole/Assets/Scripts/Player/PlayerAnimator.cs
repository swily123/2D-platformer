using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        SetYSpeed(_rigidbody.velocity.y);
    }

    public void Move(bool isMoving)
    {
        _animator.SetBool(PlayerAnimatorData.Params.IsMoving, isMoving);
    }

    public void SetOrientation(bool isGrounded)
    {
        _animator.SetBool(PlayerAnimatorData.Params.IsGrounded, isGrounded);
    }

    private void SetYSpeed(float speed)
    {
        _animator.SetFloat(PlayerAnimatorData.Params.YSpeed, speed);
    }
}