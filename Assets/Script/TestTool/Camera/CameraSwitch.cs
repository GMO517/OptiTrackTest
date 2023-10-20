using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject Camera1;
    public GameObject Camera2;
    public GameObject Camera3;


    private GameObject followedCamera;
    private bool isFollow = false;

    CameraFollow cameraFollow;

    private void Start()
    {
        cameraFollow = FindObjectOfType<CameraFollow>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Camera1.SetActive(true);
            Camera2.SetActive(false);
            Camera3.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Camera1.SetActive(false);
            Camera2.SetActive(true);
            Camera3.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Camera1.SetActive(false);
            Camera2.SetActive(false);
            Camera3.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isFollow)
            {
                cameraFollow.enabled = false;
                isFollow = false;
            }
            else
            {
                cameraFollow.enabled = true;
                isFollow = true;
            }

        }
    }
}
