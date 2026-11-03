using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonController : MonoBehaviour
{
    [SerializeField] private float _baseSpeed = 5f;
    [SerializeField] private float _jumpSpeed = 6f;
    [SerializeField] private float _gravity = -20f;
    [SerializeField] private float _mouseSensitivity = 0.1f;
    [SerializeField] private float _maxLookAngle = 80f;
    [SerializeField] private Transform _cameraTransform;

    private const float GroundedVelocity = -2f;

    private CharacterController _controller;
    private InputAction _moveAction;
    private InputAction _lookAction;
    private InputAction _jumpAction;
    private float _verticalVelocity;
    private float _pitch;
    private float _speedMultiplier = 1f;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _moveAction = InputSystem.actions.FindAction("Move");
        _lookAction = InputSystem.actions.FindAction("Look");
        _jumpAction = InputSystem.actions.FindAction("Jump");

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Vector2 look = _lookAction.ReadValue<Vector2>() * _mouseSensitivity;
        transform.Rotate(0, look.x, 0);

        _pitch = Mathf.Clamp(_pitch - look.y, -_maxLookAngle, _maxLookAngle);
        if (_cameraTransform != null)
        {
            _cameraTransform.localRotation = Quaternion.Euler(_pitch, 0, 0);
        }

        Vector2 input = _moveAction.ReadValue<Vector2>();
        float currentSpeed = _baseSpeed * _speedMultiplier;
        Vector3 velocity = (transform.right * input.x + transform.forward * input.y) * currentSpeed;

        if (_controller.isGrounded)
        {
            _verticalVelocity = GroundedVelocity;
            if (_jumpAction.WasPressedThisFrame())
            {
                _verticalVelocity = _jumpSpeed;
            }
        }

        _verticalVelocity += _gravity * Time.deltaTime;
        velocity.y = _verticalVelocity;

        _controller.Move(velocity * Time.deltaTime);
    }

    public void SetSpeedMultiplier(float multiplier)
    {
        _speedMultiplier = multiplier;
    }
}