using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnersDirector : MonoBehaviour
{
    [SerializeField] private List<GemSpawner> _spawners;

    private List<GemSpawner> _ableSpawners;
    private float _spawnDelay = 5;

    private void Awake()
    {
        _ableSpawners = new List<GemSpawner>(_spawners);
    }

    private void OnEnable()
    {
        foreach (GemSpawner spawner in _spawners)
        {
            spawner.SpawnerEnable += AddAbleSpawner;
        }
    }

    private void OnDisable()
    {
        foreach (GemSpawner spawner in _spawners)
        {
            spawner.SpawnerEnable += AddAbleSpawner;
        }
    }

    private void Start()
    {
        StartCoroutine(Spawning());
    }

    private IEnumerator Spawning()
    {
        WaitForSeconds wait = new WaitForSeconds(_spawnDelay);

        while (enabled)
        {
            if (_ableSpawners.Count == 0)
            {
                yield return new WaitUntil(() => _ableSpawners.Count > 0);
            }

            int spawnerIndex = Random.Range(0, _ableSpawners.Count);
            _ableSpawners[spawnerIndex].Spawn();
            _ableSpawners.RemoveAt(spawnerIndex);

            yield return wait;
        }
    }

    private void AddAbleSpawner(GemSpawner spawner)
    {
        _ableSpawners.Add(spawner);
    }
}
