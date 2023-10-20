using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArpgCameraControl : MonoBehaviour
{
    public InputController inputc;
    public Transform target;

    float xSpeed = 250;
    float ySpeed = 125;

    float x = 0;
    float y = 0;

    float distance = 4;
    float zoomRate = 80;
    float yMinLimit = -10;
    float yMaxLimit = 70;
    float disMinLimit = 2;
    float disMaxLimit = 10;

    Vector3 offset = new Vector3(0, 1);
    Vector3 rotateOffset = new Vector3(0.1f, 0, -1);

    // Start is called before the first frame update
    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        x += inputc.m_Camera.x * xSpeed * Time.deltaTime;
        y -= inputc.m_Camera.y * ySpeed * Time.deltaTime;
        y = ClampAngle(y, yMinLimit, yMaxLimit);

        Quaternion rotation = Quaternion.Euler(y, x, 0);
        transform.rotation = rotation;


        if (inputc.m_Movement.x != 0 || inputc.m_Movement.y != 0)
        {

            target.transform.rotation = Quaternion.Euler(0, x, 0);
        }


        distance -= (inputc.m_Camera.z * Time.deltaTime) * zoomRate * Mathf.Abs(distance);
        distance = Mathf.Clamp(distance, disMinLimit, disMaxLimit);

        transform.position = target.position + offset + rotation * (rotateOffset * distance);
    }

    float ClampAngle(float angle, float min, float max)
    {
        if (angle > 360)
        {
            angle -= 360;
        }
        else if (angle < -360)
        {
            angle += 360;
        }
        return Mathf.Clamp(angle, min, max);
    }
}
