using UnityEngine;

public class PlayerAtackSystem : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private LayerMask _layerMask;

    private float _distanceToAtack = 2;

    private void OnEnable()
    {
        _inputReader.LeftButtonClicked += Atack;
    }

    private void OnDisable()
    {
        _inputReader.LeftButtonClicked -= Atack;
    }

    private void Atack()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, _distanceToAtack, _layerMask);

        if (hit.transform == null)
        {
            return;
        }

        if (hit.transform.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_player.Damage);
        }
    }
}