using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    /// <summary>Вызывает сцену по имени.</summary>
    public void OpenMenu(string sceneName)
    {
        //Рекомендую делать так. Это избавит вас от перегрузок по коду.
        SceneManager.LoadScene(sceneName);
    }
}