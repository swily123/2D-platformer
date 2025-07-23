using UnityEngine;

public static class FrogAnimatorData
{
    public static class Params
    {
        public static readonly int IsGrounded = Animator.StringToHash(nameof(IsGrounded));
        public static readonly int Jump = Animator.StringToHash(nameof(Jump));
    }
}