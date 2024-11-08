using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadSceneAsync("TheLegendOfLocke");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
