using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    public bool autoPlay = false;
    private Ball ball;

    void Start()
    {
        ball = FindObjectOfType<Ball>();
    }

    void Update()
    {
        if (!autoPlay)
        {
            MoveWithMouse();
        }
        else
        {
            AutoPlay();
        }
    }

    private void AutoPlay()
    {
        var paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        var ballPos = ball.transform.position;
        paddlePos.x = Mathf.Clamp(ballPos.x, 0.5f, 15.5f);
        transform.position = paddlePos;
    }

    private void MoveWithMouse()
    {
        var paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        var mouseXPosition = Input.mousePosition.x / Screen.width * 16;
        paddlePos.x = Mathf.Clamp(mouseXPosition, 0.5f, 15.5f);
        transform.position = paddlePos;
    }
}
