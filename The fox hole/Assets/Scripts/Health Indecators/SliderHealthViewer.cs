using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class SliderHealthViewer : MonoBehaviour
{
    [SerializeField] private HealChanger _character;

    protected Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Start()
    {
        _slider.minValue = 0;
        _slider.maxValue = _character.HealthMaxValue;
        _slider.value = _slider.maxValue;
    }

    private void OnEnable()
    {
        _character.HealthUpdated += ChangeSliderValue;
    }

    private void OnDisable()
    {
        _character.HealthUpdated -= ChangeSliderValue;
    }

    protected virtual void ChangeSliderValue(float health)
    {
        _slider.value = health;
    }
}
