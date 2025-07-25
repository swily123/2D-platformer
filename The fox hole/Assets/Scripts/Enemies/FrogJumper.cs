using System.Collections;
using UnityEngine;

public class FrogJumper : MonoBehaviour
{
    [SerializeField] private Patroler _patroler;
    [SerializeField] private Jumper _jumper;
    [SerializeField] private FrogAnimator _animator;

    private Coroutine _coroutine;
    private bool _isJumping = true;
    private float _jumpDelay = 3f;
    private float _jumpForce = 30;

    private void Start()
    {
        _coroutine = StartCoroutine(Jump());
    }

    private void OnEnable()
    {
        _patroler.IsStartPatroling += ToggleJumping;
    }

    private void OnDisable()
    {
        _patroler.IsStartPatroling -= ToggleJumping;
    }

    private void ToggleJumping(bool isStartPatrolling)
    {
        if (isStartPatrolling)
        {
            EnableJumping();
        }
        else
        {
            StopJumping();
        }
    }

    private void EnableJumping()
    {
        if (_isJumping == false)
        {
            _coroutine = StartCoroutine(Jump());
            _isJumping = true;
        }
    }

    private void StopJumping()
    {
        if (_coroutine != null && _isJumping == true)
        {
            StopCoroutine(_coroutine);
            _isJumping = false;
        }
    }

    private IEnumerator Jump()
    {
        WaitForSeconds wait = new WaitForSeconds(_jumpDelay);

        while (enabled)
        {
            yield return wait;

            _jumper.Jump(_jumpForce);
            _animator.Jump();
            _animator.SetOrientation(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent<Ground>(out _))
        {
            _animator.SetOrientation(true);
        }
    }
}