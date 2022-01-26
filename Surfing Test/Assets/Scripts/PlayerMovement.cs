using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject cam;
    Rigidbody rb;
    float sensitivity = 3;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector3(0, 200f*rb.mass*Time.deltaTime, 0));

        
        cam.transform.eulerAngles += new Vector3(-sensitivity * Input.GetAxis("Mouse Y"),0,0);
        transform.eulerAngles += new Vector3(0,sensitivity * Input.GetAxis("Mouse X"), 0);
        rb.velocity = Quaternion.Euler(0, sensitivity* Input.GetAxis("Mouse X"), 0) * rb.velocity;
        if(Input.GetKey(KeyCode.W))
        rb.AddForce(transform.forward * 8);
        if (Input.GetKey(KeyCode.A))
            rb.AddForce(transform.right * -8);
        if (Input.GetKey(KeyCode.D))
            rb.AddForce(transform.right * 8);

    }
}
