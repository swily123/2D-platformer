using UnityEngine;

public class Player  : MonoBehaviour
{
    private float _health = 100;

    public float Damage { get; private set; } = 20;

    public void TakeDamage(float damage)
    {
        _health -= damage;
        Kill();
        Debug.Log($"{gameObject.name} - {_health} υο");
    }

    private void Kill()
    {
        if (_health <= 0)
        {
            Debug.Log("Game over.");
        }
    }
}
