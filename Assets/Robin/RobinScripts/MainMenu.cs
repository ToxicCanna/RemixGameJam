using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadSceneAsync("RobinScene");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
