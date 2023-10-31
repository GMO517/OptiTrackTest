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
        if (track.trackHead != null)
        {
            Pose HeadPose = GetPose(track.trackHead);
            cubeHead.transform.SetPositionAndRotation(HeadPose.position, HeadPose.rotation);
            Debug.Log("頭位置: " + cubeHead.transform.position + " 旋轉: " + cubeHead.transform.rotation);
        }
        if (track.trackLeftHand != null)
        {
            Pose LhandPose = GetPose(track.trackLeftHand);
            cubeLhand.transform.SetPositionAndRotation(LhandPose.position, LhandPose.rotation);
            Debug.Log("左手位置: " + cubeLhand.transform.position + " 旋轉: " + cubeLhand.transform.rotation);
        }
        if (track.trackRightHand != null)
        {
            Pose RhandPose = GetPose(track.trackRightHand);
            cubeRhand.transform.SetPositionAndRotation(RhandPose.position, RhandPose.rotation);
            Debug.Log("右手位置: " + cubeRhand.transform.position + " 旋轉: " + cubeRhand.transform.rotation);
        }
    }

    public Pose GetPose(Transform targetTrans)
    {
        Pose pose = new Pose(targetTrans.position, targetTrans.rotation);
        return pose;
    }
}
