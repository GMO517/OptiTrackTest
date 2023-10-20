using UnityEngine;
using System.Collections;
public class CameraFollow : MonoBehaviour
{

    Vector3 Dir;

    public GameObject m_Player;
    // Use this for initialization
    void Start()
    {

        Dir = m_Player.transform.position - transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        transform.position = m_Player.transform.position - Dir;
    }
}