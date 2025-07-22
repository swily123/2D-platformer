using System;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public event Action<Gem> Collected;

    public void Collect()
    {
        Collected?.Invoke(this);
        Destroy(gameObject);
    }
}
