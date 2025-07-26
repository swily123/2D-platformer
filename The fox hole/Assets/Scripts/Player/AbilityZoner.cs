using System;
using UnityEngine;

public class AbilityZoner : MonoBehaviour
{
    public event Action<HealthChanger> CharacterEntered;
    public event Action<HealthChanger> CharacterCameOut;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out HealthChanger character))
        {
            CharacterEntered(character);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out HealthChanger character))
        {
            CharacterCameOut(character);
        }
    }
}