using System.Collections;
using UnityEngine;

public class SmoothnesSliderHealthViewer : SliderHealthViewer
{
    [SerializeField] private float _maxDelta;

    protected override void ChangeSliderValue(float health)
    {
        StartCoroutine(SmoothChange(health));
    }

    private IEnumerator SmoothChange(float health)
    {
        float maxDelta = 0.15f;

        while (_slider.value != health)
        {
            float changedHealth = Mathf.MoveTowards(_slider.value, health, maxDelta);
            _slider.value = changedHealth;

            yield return null;
        }
    }
}