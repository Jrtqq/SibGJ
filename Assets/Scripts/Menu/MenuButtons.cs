using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    private const int MainSceneIndex = 1;

    public void Exit()
    {
        //здесь сохранение если надо
        Application.Quit();
    }

    public void NewGame()
    {
        //сброс сохранений
        SceneManager.LoadScene(MainSceneIndex);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(MainSceneIndex);
    }
}
