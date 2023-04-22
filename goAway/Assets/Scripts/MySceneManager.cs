using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    public static MySceneManager instance;

    void Awake()
    {
        if (instance == null)    // ��������� ��������� ��� ������
        {
            instance = this; // ������ ������ �� ��������� �������
        }
        else if (instance != this)   // ��������� ������� ��� ���������� �� �����
        {
            Destroy(gameObject); // ������� ������
            instance = this;  // ������ ������ �� ��������� �������
        }

        DontDestroyOnLoad(gameObject);  // ������ ��� ����� �������, ����� ������ �� ����������� ��� �������� �� ������ ����� ����
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
            OnExit();
    }

    public void LoadNewScene(int scenenumber)
    {
        SceneManager.LoadScene(scenenumber);
    }

    public void OnExit()
    {
        Application.Quit();
    }

    public void OpenURL()
    {
        Application.OpenURL("https://drive.google.com/drive/u/1/folders/1xwqxNDKn-W3pQvok6tTXHJgwPU4aWjgz");
    }
}
