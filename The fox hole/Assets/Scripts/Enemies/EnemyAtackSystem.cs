using System.Collections;
using UnityEngine;


public class EnemyAtackSystem : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private Patroler _patroler;
    [SerializeField] private LayerMask _layerMask;

    private float _damage = 20;
    private float _distanceToFollow = 10;
    private float _distanceToAtack = 2.4f;
    private float _atackDelay = 1.5f;
    private bool _isPatroling = true;
    private bool _canAtack = true;

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, _distanceToFollow, _layerMask);

        if (hit.transform != null)
        {
            if (hit.transform.TryGetComponent(out Player player))
            {
                _isPatroling = false;
                Vector2 direction = (player.transform.position - transform.position).normalized;

                _patroler.StopPatrole();
                _mover.Move(direction);

                if (IsEnoughToAtack(player.transform) && _canAtack)
                {
                    StartCoroutine(Atack(player));
                }
            }
        }
        else
        {
            if (_isPatroling == false)
            {
                _patroler.EnablePatrole();
                _isPatroling = true;
            }
        }
    }

    private bool IsEnoughToAtack(Transform player)
    {
        float distance = (player.position - transform.position).sqrMagnitude;
        bool isTouch = distance <= _distanceToAtack * _distanceToAtack;
        return isTouch;
    }

    private IEnumerator Atack(Player player)
    {
        _canAtack = false;
        player.TakeDamage(_damage);
        yield return new WaitForSeconds(_atackDelay);
        _canAtack = true;
    }
}