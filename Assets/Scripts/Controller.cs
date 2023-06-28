using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    private float shotStrength = 0.1f;
    private Rigidbody rb;
    [SerializeField] private Slider slider;
    [SerializeField] private LineRenderer ballFront;
    [SerializeField] private TextMeshProUGUI shootText;
    [SerializeField] private TextMeshProUGUI shootCounter;
    private bool shot = false;
    private Vector3 lineStartVector;
    private Vector3 lineEndVector;
    private float zTime;
    private int shots = 0;

    void Start()
    {
         rb = GetComponent<Rigidbody>();
        lineStartVector = ballFront.GetPosition(0);
        lineEndVector = ballFront.GetPosition(1);
    }
    private void Update()
    {
        shootCounter.text = shots.ToString();
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
        float z = Input.GetAxis("Z Axis");
        if (z > -0.95)
        {
            zTime += Time.fixedDeltaTime;
            if (zTime >= 1)
            {
                zTime = 1;
                if (!shot)
                {
                    shootText.text = "CELOWANIE";
                }
            }
        }
        else
        {
            zTime = 0;
        }
        if (zTime <= 0.3 && !shot)
        {
            shootText.text = "STRZELANIE";
        }
        if (!shot)
        {
            if (Input.GetButton("Fire3"))
            {
                Shoot();
            }
            else if (Mathf.Abs(h) > 0.3 && zTime >= 1)
            {
                ballFront.transform.Rotate(0, h * 0.7f, 0);
            }
            else if (Mathf.Abs(v) > 0.3 && zTime >= 1)
            {
                shotStrength += v * 0.01f;
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
        shots +=1;
        ballFront.enabled = false;
        shootText.text = "STRZAŁ";
    }
    private void Stop()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        shot = false;
        ballFront.enabled = true;
    }


}
