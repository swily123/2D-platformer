using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]

public class TextHealthViewer : MonoBehaviour
{
    [SerializeField] private Player _player;

    private TextMeshProUGUI _textMeshProUGUI;

    private void Awake()
    {
        _textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        ChangeText(_player.HealthMaxValue);
    }

    private void OnEnable()
    {
        _player.HealthUpdated += ChangeText;
    }

    private void OnDisable()
    {
        _player.HealthUpdated -= ChangeText;
    }

    private void ChangeText(float health)
    {
        _textMeshProUGUI.text = $"{health} / {_player.HealthMaxValue}";
    }
}