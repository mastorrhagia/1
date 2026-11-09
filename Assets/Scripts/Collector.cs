using UnityEngine;
using TMPro;

public class Collector : MonoBehaviour
{
    [SerializeField] private int _crystalsToOpen = 3;
    [SerializeField] private Door _door;
    [SerializeField] private TMP_Text _crystalsText;

    private int _crystals;

    void Start()
    {
        UpdateText();
    }

    public void AddCrystal()
    {
        _crystals++;
        UpdateText();

        if (_crystals >= _crystalsToOpen)
        {
            if (_door != null)
            {
                _door.Open();
            }

            if (_crystalsText != null)
            {
                _crystalsText.text = "<color=green>Дверь открыта</color>";
            }
        }
    }

    private void UpdateText()
    {
        if (_crystalsText != null)
        {
            _crystalsText.text = $"Кристаллы: {_crystals} / {_crystalsToOpen}";
        }
    }
}