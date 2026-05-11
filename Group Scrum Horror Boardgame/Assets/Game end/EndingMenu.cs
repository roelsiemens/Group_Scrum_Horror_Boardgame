using UnityEngine;

public class EndingMenu : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void mainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
    }

    public void restartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Final_scene");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
