using System;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public event Action<Gem> Collected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<GemCollector>(out _))
        {
            Collect();
        }
    }

    private void Collect()
    {
        Collected?.Invoke(this);
        Destroy(gameObject);
    }
}
