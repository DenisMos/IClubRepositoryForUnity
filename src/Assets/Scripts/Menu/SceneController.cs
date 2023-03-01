using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    /// <summary>�������� ����� �� �����.</summary>
    public void OpenMenu(string sceneName)
    {
        //���������� ������ ���. ��� ������� ��� �� ���������� �� ����.
        SceneManager.LoadScene(sceneName);
    }
}