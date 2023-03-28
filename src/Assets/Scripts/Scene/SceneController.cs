using Assets.Scripts.Scene;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    /// <summary>Вызывает сцену по имени.</summary>
    public void OpenMenu(string sceneName)
    {
		SceneDataNetwork.HasConnect = false;

		//Рекомендую делать так. Это избавит вас от перегрузок по коду.
		SceneManager.LoadScene(sceneName);
    }

	/// <summary>Вызывает сцену по имени.</summary>
	public void OpenMenuConnect(string sceneName)
	{
		SceneDataNetwork.HasConnect = true;

		SceneDataNetwork.Ip = Ip.text;

		//Рекомендую делать так. Это избавит вас от перегрузок по коду.
		SceneManager.LoadScene(sceneName);
	}

	public InputField Ip;
}