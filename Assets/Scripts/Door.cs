using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private float _openHeight = 3.5f; 
    [SerializeField] private float _speed = 2f;        

    private bool _isOpening;
    private float _topY;

    void Start()
    {
        _topY = transform.position.y + _openHeight;
    }

    void Update()
    {
        if (_isOpening && transform.position.y < _topY)
        {
            transform.Translate(0, _speed * Time.deltaTime, 0);
        }
    }

    public void Open()
    {
        _isOpening = true;
        Debug.Log("Все кристаллы собраны! Дверь открывается.");
    }
}