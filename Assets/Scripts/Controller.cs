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
    [SerializeField] private Image shotStateSprite;
    [SerializeField] private TextMeshProUGUI counterText;
    [SerializeField] private Sprite stateShot;
    [SerializeField] private Sprite stateAim;
    [SerializeField] private Sprite stateReady;
    private bool shot = false;
    private Vector3 lineStartVector;
    private Vector3 lineEndVector;
    private float zTime;
    private int shotcounter = 0;

    void Start()
    {
         rb = GetComponent<Rigidbody>();
        lineStartVector = ballFront.GetPosition(0);
        lineEndVector = ballFront.GetPosition(1);
    }
    private void Update()
    {
        counterText.text = shotcounter.ToString();
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
        float hMag = 1;
        float vMag = 1;
        if (z > -0.95)
        {
            zTime += Time.fixedDeltaTime;
            if (zTime >= 1)
            {
                zTime = 1;
                if (!shot)
                {
                    shotStateSprite.sprite = stateAim;
                }
            }
        }
        else
        {
            zTime = 0;
        }
        if (zTime <= 0.3 && !shot)
        {
            shotStateSprite.sprite = stateReady;
            hMag = 1;
            vMag = 1;
        }
        if (!shot)
        {
            if (Input.GetButton("Fire3"))
            {
                Shoot();
                hMag = 1;
                vMag = 1;
            }
            else if (Mathf.Abs(h) > 0.2 && zTime >= 1)
            {
                ballFront.transform.Rotate(0, h * 0.3f * hMag, 0);
                vMag = 1;
                hMag = Mathf.Clamp(hMag + 0.05f, 1, 3);
            }
            else if (Mathf.Abs(v) > 0.2 && zTime >= 1)
            {
                shotStrength += v * 0.003f * vMag;
                hMag = 1;
                vMag = Mathf.Clamp(vMag + 0.05f, 1, 3);
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
        shotcounter += 1;
        ballFront.enabled = false;
        shotStateSprite.sprite = stateShot;

    }
    private void Stop()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        shot = false;
        ballFront.enabled = true;
    }


}
