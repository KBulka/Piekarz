using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ball : MonoBehaviour
{

    [SerializeField] PaddleMovement paddle1;
    [SerializeField] float xPush;
    [SerializeField] float yPush;
    [SerializeField] bool hasStarted = false;
    [SerializeField] Rigidbody2D rb;
    Vector2 paddleToBallVector;
    private void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        rb = GetComponent<Rigidbody2D>();
        rb.simulated = false;
    }
    private void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            rb.simulated = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }
}