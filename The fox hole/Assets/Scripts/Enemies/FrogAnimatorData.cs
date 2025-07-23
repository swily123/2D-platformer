using UnityEngine;

public static class FrogAnimatorData
{
    public static class Params
    {
        public static readonly int YSpeed = Animator.StringToHash(nameof(YSpeed));
        public static readonly int Land = Animator.StringToHash(nameof(Land));
    }
}