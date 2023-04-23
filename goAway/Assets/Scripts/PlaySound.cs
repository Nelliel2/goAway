using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private string nameMusicUp;
    [SerializeField] private string nameMusicDown;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "item")
        { PlayerAudio(nameMusicDown); }
    }
    private void OnCollisionExit(Collision collision)
    {
        
    
        PlayerAudio(nameMusicUp); 
        
    }

    void PlayerAudio(string nameMusic)
    {

        FindObjectOfType<AudioManager>().Play(nameMusic);

    }
}
