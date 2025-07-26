public class Player  : HealthChanger
{
    private float _health = 100;

    public float Damage { get; private set; } = 20;

    private void Awake()
    {
        HealthMaxValue = 100;
    }

    public void Heal(float healAmount)
    {
        _health += healAmount;

        if (_health > HealthMaxValue)
        {
            _health = HealthMaxValue;
        }

        OnHealthUpdated(_health);
    }

    public override void TakeDamage(float damage)
    {
        _health -= damage;

        if (_health < 0)
        {
            _health = 0;
        }

        OnHealthUpdated(_health);
    }
}
