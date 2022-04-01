using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

    [SerializeField] Rigidbody rb;

    bool isAccel;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        CheckInput();
    }


    private void FixedUpdate()
    {
        if (isAccel)
        {
            rb.MovePosition(transform.position + new Vector3 (0, 0, 2));
        }
    }

    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            isAccel = true;
            
        }
        else
        {
            isAccel = false;
        }
    }
}
