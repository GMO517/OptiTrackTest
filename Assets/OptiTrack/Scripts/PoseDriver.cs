using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoseDriver : MonoBehaviour
{
    SkeletonTrack track;


    public GameObject cubeHead;
    public GameObject cubeLhand;
    public GameObject cubeRhand;
    void Start()
    {
        track = FindObjectOfType<SkeletonTrack>();
    }

    // Update is called once per frame
    void Update()
    {
        //手正常 頭會歪掉
        if (track.trackHead != null)
        {
            //Quaternion testRot = Quaternion.identity;
            Pose HeadPose = GetPose(track.trackHead);
            //cubeHead.transform.SetPositionAndRotation(HeadPose.position, HeadPose.rotation);
            cubeHead.transform.position = HeadPose.position;


            //Quaternion newRotation = new Quaternion(HeadPose.rotation.x, -180f, HeadPose.rotation.z, 0f);
            cubeHead.transform.rotation = HeadPose.rotation;

            //cubeHead.transform.rotation = newRotation;

            //cubeHead.transform.rotation = testRot;
            //cubeHead.transform.rotation = Quaternion.Euler(0f, 180f, 0f);


            Debug.Log("頭位置: " + cubeHead.transform.position + " 旋轉: " + cubeHead.transform.rotation);

        }
        if (track.trackLeftHand != null)
        {
            Pose LhandPose = GetPose(track.trackLeftHand);
            cubeLhand.transform.SetPositionAndRotation(LhandPose.position, LhandPose.rotation);
            //Debug.Log("左手位置: " + cubeLhand.transform.position + " 旋轉: " + cubeLhand.transform.rotation);
        }
        if (track.trackRightHand != null)
        {
            Pose RhandPose = GetPose(track.trackRightHand);
            cubeRhand.transform.SetPositionAndRotation(RhandPose.position, RhandPose.rotation);
            //Debug.Log("右手位置: " + cubeRhand.transform.position + " 旋轉: " + cubeRhand.transform.rotation);
        }


    }

    public Pose GetPose(Transform targetTrans)
    {
        Pose pose = new Pose(targetTrans.position, targetTrans.rotation);
        return pose;
    }
}
