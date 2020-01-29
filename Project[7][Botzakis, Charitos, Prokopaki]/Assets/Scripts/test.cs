using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed;

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal") * moveSpeed;
        float moveVertical = Input.GetAxis("Vertical") * moveSpeed;

        if (Input.GetKey(KeyCode.A))
        {
            Vector3 movement = new Vector3(h, 0.0f, moveVertical);

            rb.AddForce(movement);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 movement = new Vector3(h, 0.0f, moveVertical);

            rb.AddForce(movement);
        }
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 movement = new Vector3(h, 0.0f, moveVertical);

            rb.AddForce(movement);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 movement = new Vector3(h, 0.0f, moveVertical);

            rb.AddForce(movement);
        }
    }
}
