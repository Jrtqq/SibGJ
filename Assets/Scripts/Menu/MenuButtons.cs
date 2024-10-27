using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    private const int MainSceneIndex = 1;

    public void Exit()
    {
        //����� ���������� ���� ����
        Application.Quit();
    }

    public void NewGame()
    {
        //����� ����������
        SceneManager.LoadScene(MainSceneIndex);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(MainSceneIndex);
    }
}
