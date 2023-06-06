using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public Transform ball;

    void Start()
    {

    }

    void FixedUpdate()
    {

    }
    private void LateUpdate()
    {
        transform.LookAt(ball.position);
    }
}
