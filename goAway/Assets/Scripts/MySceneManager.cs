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
        else //if (instance == this)   // ��������� ������� ��� ���������� �� �����
        {
            Destroy(gameObject); // ������� ������
            return;
        }


        DontDestroyOnLoad(gameObject);  // ������ ��� ����� �������, ����� ������ �� ����������� ��� �������� �� ������ ����� ����


    }

    // Update is called once per frame
    void Update()
    {
        Exit();
    }

    public void LoadNewScene(int scenenumber)
    {
        SceneManager.LoadSceneAsync (scenenumber);
    }

    public void OnExit()
    {
        Application.Quit();
    }

    public void Exit()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            OnExit();
        }
    }

    public void OpenURL()
    {
        Application.OpenURL("https://drive.google.com/drive/u/1/folders/1xwqxNDKn-W3pQvok6tTXHJgwPU4aWjgz");
    }
}
