using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

    [SerializeField] Rigidbody rb;

    bool isAccel;
    bool isReversing;

    float direction;
    public float rotationAmount;
    public float driveSpeed;
    public float minimumSpeed;
    public float maximumSpeed;

    

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
        #region Car acceleration and reversing
        if (isAccel)
        {
            if(driveSpeed < 76)
            {
                driveSpeed = Mathf.Lerp(driveSpeed, maximumSpeed, Time.fixedDeltaTime);
                rb.MovePosition(transform.position + transform.forward * driveSpeed * Time.fixedDeltaTime);
            }
            else
            {
                driveSpeed = Mathf.Lerp(driveSpeed, maximumSpeed, 2f);
                rb.MovePosition(transform.position + transform.forward * driveSpeed * Time.fixedDeltaTime);
            }
        }
        else
        {
            if(driveSpeed > 5)
            {
                driveSpeed = Mathf.Lerp(driveSpeed, minimumSpeed, Time.fixedDeltaTime);
                rb.MovePosition(transform.position + transform.forward * driveSpeed * Time.fixedDeltaTime);
            }
            else
            {
                driveSpeed = 0;
            }
        }
        if (isReversing)
        {
            driveSpeed = Mathf.Lerp(driveSpeed, minimumSpeed,  1.5f * Time.deltaTime);
            rb.MovePosition(transform.position + transform.forward * driveSpeed * Time.fixedDeltaTime);
        }

        direction = Input.GetAxisRaw("Horizontal");
        transform.Rotate(0, direction * rotationAmount * Time.fixedDeltaTime, 0);

        print(direction);
        #endregion
    }

    private void CheckInput()
    {
        isAccel = Input.GetKey(KeyCode.W);
        isReversing = Input.GetKey(KeyCode.S);
    }
}
