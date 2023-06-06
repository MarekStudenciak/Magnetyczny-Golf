using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    private float shotStrength = 0.1f;
    private Rigidbody rb;
    [SerializeField] private Slider slider;
    [SerializeField] private LineRenderer ballFront;
    private bool shot = false;
    private Vector3 lineStartVector;
    private Vector3 lineEndVector;

    void Start()
    {
         rb = GetComponent<Rigidbody>();
        lineStartVector = ballFront.GetPosition(0);
        lineEndVector = ballFront.GetPosition(1);
    }
    private void Update()
    {
        RaycastHit hit;
        Vector3 vec = ballFront.transform.TransformPoint(lineStartVector - new Vector3(0, 0, 0.1f));
        if (Physics.Raycast(vec, ballFront.transform.forward, out hit, (lineEndVector - lineStartVector).magnitude * shotStrength))
        {
            ballFront.SetPosition(1, ballFront.transform.InverseTransformPoint(hit.point));
        }
        else
        {
            ballFront.SetPosition(1, lineStartVector + lineEndVector * shotStrength);
        }
    }
    void FixedUpdate()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        if (!shot)
        {
            if (Input.GetButton("Fire1"))
            {
                Shoot();
            }
            else if (Mathf.Abs(h) > 0.3)
            {
                ballFront.transform.Rotate(0, h, 0);
            }
            else if (Mathf.Abs(v) > 0.3)
            {
                shotStrength += v * 0.03f;
            }
        }
        else if (rb.velocity.magnitude < 1)
        {
            Stop();
        }
        shotStrength = Mathf.Clamp(shotStrength, 0.1f, 1);
        slider.value = shotStrength;
    }

    private void LateUpdate()
    {
        ballFront.transform.position = transform.position;
    }
    private void Shoot()
    {
        rb.AddForce(1000f * Mathf.Pow(shotStrength + 1, 2) * shotStrength * ballFront.transform.forward);
        shot = true;
        ballFront.enabled = false;
    }
    private void Stop()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        shot = false;
        ballFront.enabled = true;
    }


}
