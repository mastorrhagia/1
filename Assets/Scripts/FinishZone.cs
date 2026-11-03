using UnityEngine;

public class FinishZone : MonoBehaviour
{
    private bool _isFinished;

    void OnTriggerEnter(Collider other)
    {
        if (!_isFinished && other.TryGetComponent(out FirstPersonController player))
        {
            _isFinished = true;
            float finalTime = Time.timeSinceLevelLoad;
            Debug.LogError($"ФИНИШ! Уровень пройден за {finalTime:F2} сек.");
        }
    }
}