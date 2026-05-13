using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_script : MonoBehaviour
{


    public void StartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Afsluiten()
    {
        Application.Quit();
    }
}
