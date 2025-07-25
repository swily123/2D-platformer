using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroler : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private List<Transform> _points;

    public event Action<bool> IsStartPatroling;
    public bool IsPatroling { get; private set; } = true;

    private Coroutine _coroutine;
    private int _currentPoint = 0;
    private float _patroleDelay = 1.5f;
    private float _minDistanceToPoint = 0.05f;

    private void Start()
    {
        EnablePatrole();
    }

    public void EnablePatrole()
    {
        IsStartPatroling?.Invoke(true);
        _coroutine = StartCoroutine(Patrolling());
        IsPatroling = true;
    }

    public void StopPatrole()
    {
        if (_coroutine != null)
        {
            IsPatroling = false;
            StopCoroutine(_coroutine);
            IsStartPatroling?.Invoke(false);
        }
    }

    private IEnumerator Patrolling()
    {
        WaitForSeconds wait = new WaitForSeconds(_patroleDelay);

        while (enabled)
        {
            Transform targetPoint = GetPoint();
            Vector2 direction = (targetPoint.position - transform.position).normalized;

            while (IsTouchPoint(targetPoint) == false)
            {
                _mover.Move(direction);
                yield return null;
            }

            _currentPoint++;
            yield return wait;
        }
    }

    private bool IsTouchPoint(Transform point)
    {
        Vector2 position = transform.position * Vector2.right;
        Vector2 pointPosition = point.position * Vector2.right;

        float distance = (pointPosition - position).sqrMagnitude;

        bool isTouch = distance <= _minDistanceToPoint * _minDistanceToPoint;
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
        }

        return point;
    }
}