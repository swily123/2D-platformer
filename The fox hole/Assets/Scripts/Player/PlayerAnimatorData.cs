using UnityEngine;

public static class PlayerAnimatorData
{
    public static class Params
    {
        public static readonly int Jump = Animator.StringToHash(nameof(Jump));
        public static readonly int IsGrounded = Animator.StringToHash(nameof(IsGrounded));
        public static readonly int IsMoving = Animator.StringToHash(nameof(IsMoving));
    }
}