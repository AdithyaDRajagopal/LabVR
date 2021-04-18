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

    void Start()
    {
        InitPos = transform.position;
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

}