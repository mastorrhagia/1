using UnityEngine;
using TMPro;

public class FinishZone : MonoBehaviour
{
    [SerializeField] private GameObject _finishPanel;
    [SerializeField] private TMP_Text _timeText;
    [SerializeField] private FirstPersonController _playerController;

    private bool _isFinished;

    void OnTriggerEnter(Collider other)
    {
        if (!_isFinished && other.TryGetComponent(out FirstPersonController player))
        {
            _isFinished = true;
            float finalTime = Time.timeSinceLevelLoad;

            if (_timeText != null)
            {
                _timeText.text = $"Время: {finalTime:F2} сек.";
            }

            if (_finishPanel != null)
            {
                _finishPanel.SetActive(true);
            }

            Time.timeScale = 0f;
            if (_playerController != null) _playerController.enabled = false;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}