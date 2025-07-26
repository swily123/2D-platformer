using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]

public class TextHealthViewer : MonoBehaviour
{
    [SerializeField] private HealthChanger _character;

    private TextMeshProUGUI _textMeshProUGUI;

    private void Awake()
    {
        _textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        ChangeText(_character.HealthMaxValue);
    }

    private void OnEnable()
    {
        _character.HealthUpdated += ChangeText;
    }

    private void OnDisable()
    {
        _character.HealthUpdated -= ChangeText;
    }

    private void ChangeText(float health)
    {
        _textMeshProUGUI.text = $"{health} / {_character.HealthMaxValue}";
    }
}