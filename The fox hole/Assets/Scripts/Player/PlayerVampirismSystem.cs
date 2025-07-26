using System.Collections;
using UnityEngine;

public class PlayerVampirismSystem : MonoBehaviour
{
    [SerializeField] private VampirismViewer _vampirismViewer;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private GameObject _abilityView;

    public bool IsAviable { get; private set; } = false;
    public float AbilityDuration { get; private set; } = 6;
    public float RechargeDuration { get; private set; } = 4;

    private bool _canBeActive = true;

    private void Start()
    {
        SetActiveAbility(IsAviable);
    }

    private void OnEnable()
    {
        _inputReader.AbilityPressed += AbilityHandler;
    }

    private void OnDisable()
    {
        _inputReader.AbilityPressed -= AbilityHandler;
    }

    private void AbilityHandler()
    {
        if (IsAviable == false && _canBeActive)
        {
            StartCoroutine(EnableVampirism());
        }
    }

    private IEnumerator EnableVampirism()
    {
        _canBeActive = false;
        SetActiveAbility(true);
        yield return new WaitForSeconds(AbilityDuration);
        SetActiveAbility(false);

        StartCoroutine(Recharge());
    }

    private IEnumerator Recharge()
    {
        _vampirismViewer.RechargeStatus();
        yield return new WaitForSeconds(RechargeDuration);
        SetActiveAbility(false);
        _canBeActive = true;
    }

    private void SetActiveAbility(bool isActive)
    {
        IsAviable = isActive;
        _abilityView.SetActive(isActive);
        _vampirismViewer.ChangeStatus(isActive);
    }
}