using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Movement : MonoBehaviour
{
    [SerializeField] private Fliper _fliper;

    private float _speed = 8;
    private Animator _animator;
    private readonly string Horizontal = nameof(Horizontal);

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float direction = Input.GetAxisRaw(Horizontal);

        Move(direction);
        _fliper.Flip(direction);
    }

    private void Move(float direction)
    {
        _animator.SetBool("isMoving", direction != 0);
        transform.Translate(Vector2.right * direction * _speed * Time.deltaTime);
    }
}
