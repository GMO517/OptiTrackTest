using UnityEngine;
using System.Collections;
public class CameraFollow : MonoBehaviour
{

    Vector3 Dir;
    public float speed = 5.0f;
    public float sensitivity = 5.0f;

    public GameObject m_Player;

    private Camera cameraConponent;
    private int maxView = 120;
    private int minView = 10;
    private float slideSpeed = 50;
    void Start()
    {
        cameraConponent = this.GetComponent<Camera>();
        Dir = m_Player.transform.position - transform.position;
    }

    private void Update()
    {
        transform.position += transform.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.position += transform.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        transform.eulerAngles += new Vector3(-mouseY * sensitivity, mouseX * sensitivity, 0);
        ScrollCamera(); //縮放鏡頭腳本
    }
    void LateUpdate()
    {

        transform.position = m_Player.transform.position - Dir;
    }
    private void ScrollCamera()
    {
        float mouseCenter = Input.GetAxis("Mouse ScrollWheel");
        //mouseCenter < 0  = 負數 往後滾動 縮小鏡頭
        if (mouseCenter < 0)
        {
            if (cameraConponent.fieldOfView <= maxView)
            {
                cameraConponent.fieldOfView += 10 * slideSpeed * Time.deltaTime;
                if (cameraConponent.fieldOfView >= maxView)
                {
                    cameraConponent.fieldOfView = minView;
                }
            }
        }

        //mouseCenter > 0  = 正數 往前滾動 放大鏡頭
        else if (mouseCenter > 0)
        {
            if (cameraConponent.fieldOfView >= minView)
            {
                cameraConponent.fieldOfView -= 10 * slideSpeed * Time.deltaTime;
                if (cameraConponent.fieldOfView <= minView)
                {
                    cameraConponent.fieldOfView = maxView;
                }
            }
        }
    }
}