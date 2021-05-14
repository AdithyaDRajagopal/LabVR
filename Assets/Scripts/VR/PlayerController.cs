using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Quaternion InitRot;
    // Start is called before the first frame update
    void Start()
    {
        InitRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        transform.rotation = InitRot;
        if (Input.GetKey("w"))
            rb.AddForce(Vector3.up);
        if (Input.GetKey("s"))
            rb.AddForce(Vector3.down);
        if (Input.GetKey("a"))
            rb.AddForce(Vector3.left);
        if (Input.GetKey("d"))
            rb.AddForce(Vector3.right);
        if (Input.GetKey(KeyCode.UpArrow))
            rb.AddForce(Vector3.forward);
        if (Input.GetKey(KeyCode.DownArrow))
            rb.AddForce(Vector3.back);
    }
}
