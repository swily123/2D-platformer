using System;
using UnityEngine;

public abstract class HealthChanger : MonoBehaviour
{
    public event Action<float> HealthUpdated;
    public float HealthMaxValue { get; protected set; }

    public abstract void TakeDamage(float damage);

    public void SetActiveVampirism()
    {

    }

    protected virtual void OnHealthUpdated(float health)
    {
        HealthUpdated?.Invoke(health);
    }
}