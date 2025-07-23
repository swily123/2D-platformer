using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void Move(bool isMoving)
    {
        _animator.SetBool(PlayerAnimatorData.Params.IsMoving, isMoving);
    }

    public void SetOrientation(bool isGrounded)
    {
        _animator.SetBool(PlayerAnimatorData.Params.IsGrounded, isGrounded);
    }

    public void Jump()
    {
        _animator.SetTrigger(PlayerAnimatorData.Params.Jump);
    }
}