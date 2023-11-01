using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoseDriver : MonoBehaviour
{
    SkeletonTrack track;


    public GameObject cubeHead;
    public GameObject cubeLhand;
    public GameObject cubeRhand;
    public GameObject dice;

    //public Quaternion headOffset;
    public Quaternion lHandOffset;
    public Quaternion rHandOffset;


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
            //Quaternion yOffset = new Quaternion(-HeadPose.rotation.y, -HeadPose.rotation.z, HeadPose.rotation.x, HeadPose.rotation.w);
            Quaternion yOffset = Quaternion.Euler(-90f, 0f, 90f); //人物軸心跟攝影機不同的話要記得改這邊 看XYZ軸相差多少
            cubeHead.transform.position = HeadPose.position;
            cubeHead.transform.rotation = HeadPose.rotation * yOffset;

            dice.transform.position = HeadPose.position;
            dice.transform.rotation = HeadPose.rotation;

            Debug.Log("頭數據1:" + HeadPose.position.GetType());
            Debug.Log("頭位置:" + cubeHead.transform.position);
            Debug.Log("頭數據2:" + HeadPose.rotation);
            Debug.Log("頭轉:" + cubeHead.transform.rotation);
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

    //轉換坐標系統用 動補是右手系 unity是左手系
    private Vector3 ConvertCoordinateSystemPos(Vector3 rightHandedVector)
    {
        return new Vector3(rightHandedVector.x, rightHandedVector.z, rightHandedVector.y);
    }

    private Quaternion ConvertCoordinateSystemRot(Quaternion rightHandedQuaternion)
    {
        return new Quaternion(
            -rightHandedQuaternion.x,
            -rightHandedQuaternion.z,
            -rightHandedQuaternion.y,
            rightHandedQuaternion.w);

        //return new Quaternion(
        //    -rightHandedQuaternion.x,
        //    -rightHandedQuaternion.y,
        //    -rightHandedQuaternion.z,
        //    rightHandedQuaternion.w);

    }
}
