using Assets.Scripts.Scene;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    /// <summary>�������� ����� �� �����.</summary>
    public void OpenMenu(string sceneName)
    {
		SceneDataNetwork.HasConnect = false;

		//���������� ������ ���. ��� ������� ��� �� ���������� �� ����.
		SceneManager.LoadScene(sceneName);
    }

	/// <summary>�������� ����� �� �����.</summary>
	public void OpenMenuConnect(string sceneName)
	{
		SceneDataNetwork.HasConnect = true;

		SceneDataNetwork.Ip = Ip.text;

		//���������� ������ ���. ��� ������� ��� �� ���������� �� ����.
		SceneManager.LoadScene(sceneName);
	}

	public InputField Ip;
}