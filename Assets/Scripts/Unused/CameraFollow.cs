using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float followSpeed = 15f;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, followSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, followSpeed * Time.deltaTime);
    }
}
