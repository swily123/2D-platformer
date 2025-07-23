using UnityEngine;

public class Player  : MonoBehaviour
{
    private float _health = 100;

    public float Damage { get; private set; } = 20;

    public void TakeDamage(float damage)
    {
        _health -= damage;
    }
}
