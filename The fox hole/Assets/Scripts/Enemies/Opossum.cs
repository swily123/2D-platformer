using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opossum : MonoBehaviour
{
    [SerializeField] private Fliper _fliper;
    [SerializeField] private List<Transform> _points;

    private float _minDistanceToPoint = 0.05f;
    private float _patroleDelay = 1.5f;
    private float _speed = 3;
    private int _currentPoint = 0;

    private void Start()
    {
        StartCoroutine(Patrolling(_speed));
    }

    private IEnumerator Patrolling(float speed)
    {
        while (enabled)
        {
            Transform targetPoint = GetPoint();
            Vector2 direction = (targetPoint.position - transform.position).normalized;

            while (IsTouchPoint(targetPoint) == false)
            {
                Move(direction);
                yield return null;
            }

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

    private void Move(Vector2 direction)
    {
        _fliper.Flip(-direction.x);

        if (direction.x < 0)
        {
            transform.Translate(Vector2.left * _speed * Time.deltaTime);
        }
        else
        { 
            transform.Translate(Vector2.right * _speed * Time.deltaTime);
        }
    }
}
