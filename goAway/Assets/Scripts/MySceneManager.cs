using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    public static MySceneManager instance;
    void Awake()
    {
        if (instance == null)    // Ёкземпл€р менеджера был найден
        {
            instance = this; // «адаем ссылку на экземпл€р объекта
        }
        else //if (instance == this)   // Ёкземпл€р объекта уже существует на сцене
        {
            Destroy(gameObject); // ”дал€ем объект
            return;
        }


        DontDestroyOnLoad(gameObject);  // “еперь нам нужно указать, чтобы объект не уничтожалс€ при переходе на другую сцену игры


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
