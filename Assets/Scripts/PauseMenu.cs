using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private FirstPersonController _playerController;

    private bool _isPaused;
    private CursorLockMode _savedCursorMode;

    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (_isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Pause()
    {
        _isPaused = true;
        _panel.SetActive(true);
        Time.timeScale = 0f; 
        if (_playerController != null) _playerController.enabled = false;
        _savedCursorMode = Cursor.lockState;
        Cursor.lockState = CursorLockMode.None; 
    }

    public void Resume()
    {
        _isPaused = false;
        _panel.SetActive(false);
        Time.timeScale = 1f; 
        if (_playerController != null) _playerController.enabled = true;
        Cursor.lockState = _savedCursorMode;
    }

    public void Restart()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("MainMenu");
    }
}