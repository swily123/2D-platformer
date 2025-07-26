using UnityEngine;

public class Enemy : HealthChanger
{
    [SerializeField] private Patroler _patroler;
    [SerializeField] private Mover _mover;

    private float _health = 50;

    private void Awake()
    {
        HealthMaxValue = _health;
    }

    public override void TakeDamage(float damage)
    {
        _health -= damage;
        OnHealthUpdated(_health);
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
