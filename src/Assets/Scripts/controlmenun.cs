using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controlmenun : MonoBehaviour
{
	public GameObject Menu;
	private void Start()
	{
		Menu.SetActive(false);
	}
	private void Update()

	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			ShowOrHide();
		}
	}
	public void ShowOrHide()
	{
		if (Menu.activeSelf)
		{
			Menu.SetActive(false);
			Time.timeScale = 1f;
		}
		else
		{
			Menu.SetActive(true);
			Time.timeScale = 0f;
		}
	}

	public void load(string name)
	{

		SceneManager.LoadScene(name, LoadSceneMode.Single);
	}
}
