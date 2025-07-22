using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Fliper _fliper;
    [SerializeField] private List<Transform> _points;

    private Rigidbody2D _rigidbody;
    private float _minDistanceToPoint = 0.05f;
    private float _patroleDelay = 1f;
    private float _speed = 5.5f;
    private float _jumpForce = 30;
    private int _currentPoint = 0;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        StartCoroutine(Patrolling(_speed));
    }

    private void Update()
    {
        float ySpeed = _rigidbody.velocity.y;

        if (ySpeed == 0)
        {
            _animator.SetTrigger("Land");
        }
        else
        {

            _animator.SetFloat("Yspeed", ySpeed);
        }
    }

    private IEnumerator Patrolling(float speed)
    {
        while (enabled)
        {
            Jump();
            Coroutine corutine = StartCoroutine(Move(GetPoint()));

            yield return corutine;
            yield return new WaitForSeconds(_patroleDelay);
        }
    }

    private bool IsTouchPoint(Transform point)
    {
        Vector2 position = transform.position * Vector2.right;
        Vector2 pointPosition = point.position * Vector2.right;

        bool isTouch = Vector2.Distance(position, pointPosition) <= _minDistanceToPoint;
        return isTouch;
    }

    private Transform GetPoint()
    {
        Transform point = null;

        if (_points.Count > 0)
        {

            if (_currentPoint == _points.Count)
            {
                _currentPoint = 0;
            }

            point = _points[_currentPoint];
            _currentPoint++;
        }

        return point;
    }

    private IEnumerator Move(Transform targetPoint)
    {
        Vector2 direction = (targetPoint.position - transform.position).normalized;

        while (IsTouchPoint(targetPoint) == false)
        {
            _fliper.Flip(-direction.x);
            transform.Translate(Vector2.right * direction * _speed * Time.deltaTime);
            yield return null;
        }

        yield break;
    }

    private void Jump()
    {
        _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }
}