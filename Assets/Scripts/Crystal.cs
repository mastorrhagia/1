using UnityEngine;

public class Crystal : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Collector collector))
        {
            collector.AddCrystal();
            Destroy(gameObject); 
        }
    }
}