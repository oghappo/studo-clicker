using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Метод для перехода в мини-игру
    public void GoToMiniGame()
    {
        SceneManager.LoadScene("MiniGame");
    }

    // Метод для возврата в главное меню
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("SampleScene"); // Убедись, что имя совпадает с твоей главной сценой
    }
   



    // Метод, который мы будем вызывать при нажатии на кнопку
    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}