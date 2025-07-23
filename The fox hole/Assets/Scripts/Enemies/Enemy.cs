using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Patroler _patroler;
    [SerializeField] private Mover _mover;

    private float _health = 50;

    public void TakeDamage(float damage)
    {
        _health -= damage;
        Kill();
    }

    private void Kill()
    {
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
