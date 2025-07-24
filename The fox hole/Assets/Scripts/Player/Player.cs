using UnityEngine;

public class Player  : MonoBehaviour
{
    private float _health = 100;
    private float _healthMaxValue = 100;
    private float _healValue = 15;

    public float Damage { get; private set; } = 20;

    public void Heal()
    {
        _health += _healValue;

        if (_health > _healthMaxValue)
        {
            _health = _healthMaxValue;
        }

        Debug.Log($"{transform.name} | {_health} hp");
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;

        Debug.Log($"{transform.name} | {_health} hp");

        if (_health <= 0)
        {
            Debug.Log("Game over");
        }
    }
}
