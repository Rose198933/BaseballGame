using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTrackingCamera : MonoBehaviour
{
    private GameObject ball;
    private Vector3 offset;

    void Start()
    {
        ball = GameObject.Find("Ball");
        Vector3 ballPos = ball.transform.position;
        transform.position = new Vector3(ballPos.x, ballPos.y, ballPos.z - 3f);

        offset = transform.position - ball.transform.position;
    }

    void Update()
    {
        this.transform.position = ball.transform.position + offset;
    }
}
