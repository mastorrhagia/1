using UnityEngine;
using TMPro;

public class LevelTimer : MonoBehaviour
{
    [SerializeField] private TMP_Text _timerText;

    void Update()
    {
        if (_timerText != null)
        {
            _timerText.text = Time.timeSinceLevelLoad.ToString("0");
        }
    }
}