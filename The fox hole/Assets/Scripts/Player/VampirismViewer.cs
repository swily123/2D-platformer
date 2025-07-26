using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VampirismViewer : MonoBehaviour
{
    [SerializeField] private PlayerVampirismSystem _system;
    [SerializeField] private TextMeshProUGUI _status;
    [SerializeField] private Image _image;

    public void ChangeStatus(bool isActive)
    {
        if (isActive == false)
        {
            _status.text = "Ability ready.";
        }
        else
        {
            _status.text = "Ability using...";
            StartCoroutine(RechargingAnimation(0, _system.AbilityDuration));
        }
    }

    public void RechargeStatus()
    {
        _status.text = "Recharging...";
        StartCoroutine(RechargingAnimation(1, _system.RechargeDuration));
    }

    private IEnumerator RechargingAnimation(float end, float duration)
    {
        float currentAmount = _image.fillAmount;
        float step = Mathf.Abs((end - currentAmount) / duration);

        while (_image.fillAmount != end)
        {
            _image.fillAmount = Mathf.MoveTowards(_image.fillAmount, end, step * Time.deltaTime);
            yield return null;
        }
    }
}