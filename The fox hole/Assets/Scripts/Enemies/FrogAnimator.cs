using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class FrogAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _animator.SetFloat(FrogAnimatorData.Params.YSpeed, _rigidbody2D.velocity.y);
    }

    public void Land()
    {
        _animator.SetTrigger(FrogAnimatorData.Params.Land);
    }
}