using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed = 3;
    [SerializeField] private float mouseSensetivity = 2;
    [SerializeField] private Transform cameraTransform;
    private float horizontal;
    private float vertical;
    private float mouseX;
    private float mouseY;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        FindObjectOfType<AudioManager>().Play("background");
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        PlayerGo();
        PlayerStepAudio();
    }

    void Update()
    {
        
        PlayerRotate();

        /*horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        //Vector3 dir = new Vector3 (horizontal, 0, vertical);
        Vector3 dir = cameraTransform.forward * vertical + cameraTransform.right * horizontal;
        rb.velocity = Vector3.ClampMagnitude(dir, 1) * speed;

       if (rb.velocity.x != 0f) 
        {
            FindObjectOfType<AudioManager>().Play("playerSteps");
            Debug.Log("horizontal = " + horizontal);
            Debug.Log("vertical "+ vertical);
        }
            
        else
            //FindObjectOfType<AudioManager>().Stop("playerSteps");



        if (cameraTransform.rotation.eulerAngles.x - mouseY > 280 || cameraTransform.rotation.eulerAngles.x - mouseY < 80)
            cameraTransform.rotation = Quaternion.Euler(cameraTransform.rotation.eulerAngles.x - mouseY* mouseSensetivity, cameraTransform.rotation.eulerAngles.y, cameraTransform.rotation.eulerAngles.z);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseX* mouseSensetivity, transform.rotation.eulerAngles.z);   
*/
    }

    void PlayerGo()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
              

        //Vector3 dir = new Vector3 (horizontal, 0, vertical);
        Vector3 dir = cameraTransform.forward * vertical + cameraTransform.right * horizontal;
        rb.velocity = Vector3.ClampMagnitude(dir, 1) * speed;
                       
    }

    void PlayerRotate() 
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        if (cameraTransform.rotation.eulerAngles.x - mouseY > 280 || cameraTransform.rotation.eulerAngles.x - mouseY < 80)
            cameraTransform.rotation = Quaternion.Euler(cameraTransform.rotation.eulerAngles.x - mouseY * mouseSensetivity, cameraTransform.rotation.eulerAngles.y, cameraTransform.rotation.eulerAngles.z);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseX * mouseSensetivity, transform.rotation.eulerAngles.z);

    }

    void PlayerStepAudio()
    {
        if ((rb.velocity.x == 0f && rb.velocity.z == 0f))
        {
            FindObjectOfType<AudioManager>().Play("playerSteps");
           
        }
    }
}



