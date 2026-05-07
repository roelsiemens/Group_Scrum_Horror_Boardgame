using UnityEngine;

public class EndingMenu : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void mainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main_menu");
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
