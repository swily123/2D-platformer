using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]

public class VampirismAtacker : MonoBehaviour
{
    [SerializeField] private PlayerVampirismSystem _vampirismSystem;
    [SerializeField] private AbilityZoner _abilityZoner;

    private Player _player;
    private float _vampirismAmount = 7;
    private float _damageDelay = 0.5f;
    private Dictionary<HealthChanger, Coroutine> _coroutines = new Dictionary<HealthChanger, Coroutine>();

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        _abilityZoner.CharacterEntered += StartVampirism;
        _abilityZoner.CharacterCameOut += StopVampirism;
    }

    private void OnDisable()
    {
        _abilityZoner.CharacterEntered -= StartVampirism;
        _abilityZoner.CharacterCameOut -= StopVampirism;
    }

    private void StartVampirism(HealthChanger character)
    {
        if (_vampirismSystem.IsAviable && _coroutines.ContainsKey(character) == false)
        {
            Coroutine coroutine = StartCoroutine(VampirismOnCharacter(character));
            _coroutines.Add(character, coroutine);
        }
    }

    private void StopVampirism(HealthChanger character)
    {
        if (_coroutines.ContainsKey(character))
        {
            StopCoroutine(_coroutines[character]);
            _coroutines.Remove(character);
        }
    }

    private IEnumerator VampirismOnCharacter(HealthChanger character)
    {
        WaitForSeconds wait = new WaitForSeconds(_damageDelay);

        while (enabled)
        {
            character.TakeDamage(_vampirismAmount);
            _player.Heal(_vampirismAmount);
            yield return wait;
        }
    }
}