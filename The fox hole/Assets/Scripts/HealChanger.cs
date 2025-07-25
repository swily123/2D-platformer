using System;
using UnityEngine;

public abstract class HealChanger : MonoBehaviour
{
    public event Action<float> HealthUpdated;
    public float HealthMaxValue { get; protected set; }

    protected virtual void OnHealthUpdated(float health)
    {
        HealthUpdated?.Invoke(health);
    }
}