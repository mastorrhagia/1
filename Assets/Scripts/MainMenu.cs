using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Time.timeScale = 1f;
        
        SceneManager.LoadScene("2");
    }

    public void QuitGame()
    {
        Debug.Log("Кнопка 'Выход' нажата. Приложение закрывается.");
        Application.Quit();
    }
}