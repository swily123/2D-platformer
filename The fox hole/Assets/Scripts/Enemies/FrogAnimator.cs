using UnityEngine;

public class FrogAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void SetOrientation(bool isGrounded)
    {
        _animator.SetBool(FrogAnimatorData.Params.IsGrounded, isGrounded);
    }

    public void Jump()
    {
        _animator.SetTrigger(FrogAnimatorData.Params.Jump);
    }
}