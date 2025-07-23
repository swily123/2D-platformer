using UnityEngine;

public class FrogJumper : MonoBehaviour
{
    [SerializeField] private Patroler _patroler;
    [SerializeField] private FrogAnimator _animator;

    private Rigidbody2D _rigidbody;
    private float _jumpForce = 30;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

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
        _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        _animator.Jump();
        _animator.SetOrientation(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent<Ground>(out _))
        {
            _animator.SetOrientation(true);
        }
    }
}