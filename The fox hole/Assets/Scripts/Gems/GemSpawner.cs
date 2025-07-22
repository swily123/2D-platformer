using System;
using UnityEngine;

public class GemSpawner : MonoBehaviour
{
    [SerializeField] private Gem _gemPrefab;

    public event Action<GemSpawner> SpawnerEnable;

    public void Spawn()
    {
        Gem gem = Instantiate(_gemPrefab, transform.position, Quaternion.identity);
        gem.Collected += ActionOnGemCollected;
    }

    private void ActionOnGemCollected(Gem gem)
    {
        gem.Collected -= ActionOnGemCollected;
        SpawnerEnable?.Invoke(this);
    }
}
