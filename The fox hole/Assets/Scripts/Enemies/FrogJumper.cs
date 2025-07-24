using UnityEngine;

public class FrogJumper : MonoBehaviour
{
    [SerializeField] private Jumper _jumper;
    [SerializeField] private Patroler _patroler;
    [SerializeField] private FrogAnimator _animator;

    private float _jumpForce = 30;

    private void OnEnable()
    {
        _patroler.PatrolStarted += Jump;
    }

    private void OnDisable()
    {
        _patroler.PatrolStarted -= Jump;
    }

    private void Jump()
    {
        _jumper.Jump(_jumpForce);
        _animator.Jump();
        _animator.SetOrientation(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent<Ground>(out _))
        {
            _animator.SetOrientation(true);
        }
    }
}