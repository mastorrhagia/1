using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] private float _speed = 90f; 
    [SerializeField] private Vector3 _axis = Vector3.up; 

    void Update()
    {
        transform.Rotate(_axis * _speed * Time.deltaTime);
    }
}