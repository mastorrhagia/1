using UnityEngine;

public class SpeedBoostZone : MonoBehaviour
{
    [SerializeField] private float _multiplier = 2f; 

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out FirstPersonController player))
        {
            player.SetSpeedMultiplier(_multiplier);
            Debug.Log("Зона ускорения! Скорость x2");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out FirstPersonController player))
        {
            player.SetSpeedMultiplier(1f);
            Debug.Log("Обычная скорость");
        }
    }
}