using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Test : MonoBehaviour
{
    private Action a;
    void Start()
    {
        a = WriteHello;      
        
    }

    private void WriteHello()
    {
        Debug.Log("Hello");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            a.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            a = WriteHello;
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            a = WriteBay;
        }
    }

    private void WriteBay()
    {
        Debug.Log("Bay");
    }
}
