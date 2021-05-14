using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PendulumBehaviour : MonoBehaviour
{
    private float maxZangle;
    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 InitPos;
    private Quaternion InitRot;
    int count;
    Rigidbody Pendulum;

    void Start()
    {
        InitPos = transform.position;
        InitRot = transform.rotation;
        count = 0;
    }

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }
 
    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }

    public void Reset()
    {
        count = (count+1)%3;
        if (count == 0)
        {
            Pendulum = GetComponent<Rigidbody>();
            transform.position = InitPos;
            transform.rotation = InitRot;
            Pendulum.velocity = Vector3.zero;
            Pendulum.angularVelocity = Vector3.zero;
        }
    }

}