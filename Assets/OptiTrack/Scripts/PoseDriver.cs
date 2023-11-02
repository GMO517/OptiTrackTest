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
        UpdatePose();
    }

    public Pose GetPose(Transform targetTrans)
    {
        Pose pose = new Pose(targetTrans.position, targetTrans.rotation);
        return pose;
    }

    private void UpdatePose()
    {
        if (track.trackHead != null)
        {
            Pose HeadPose = GetPose(track.trackHead);
            Quaternion yOffset = Quaternion.Euler(-90f, 0f, 90f); //人物軸心跟攝影機不同的話要記得改這邊 看XYZ軸相差多少
            cubeHead.transform.position = HeadPose.position;
            cubeHead.transform.rotation = HeadPose.rotation * yOffset;

            dice.transform.position = HeadPose.position;
            dice.transform.rotation = HeadPose.rotation;

            //Debug.Log("頭數據1:" + HeadPose.position.GetType());
            //Debug.Log("頭位置:" + cubeHead.transform.position);
            //Debug.Log("頭數據2:" + HeadPose.rotation);
            //Debug.Log("頭轉:" + cubeHead.transform.rotation);
        }
        if (track.trackLeftHand != null)
        {
            Pose LhandPose = GetPose(track.trackLeftHand);
            Quaternion lHandOffset = Quaternion.Euler(-90f, 0f, 90f); //人物軸心跟攝影機不同的話要記得改這邊 看XYZ軸相差多少
            cubeLhand.transform.SetPositionAndRotation(LhandPose.position, LhandPose.rotation * lHandOffset);
            Vector3 leftAng = cubeLhand.transform.rotation.eulerAngles;
            //Debug.Log("左手位置: " + cubeLhand.transform.position + " 旋轉: " + cubeLhand.transform.rotation);
            Debug.Log("左手位置: " + cubeLhand.transform.position + " 旋轉: " + leftAng);
        }
        if (track.trackRightHand != null)
        {
            Pose RhandPose = GetPose(track.trackRightHand);
            Quaternion rHandOffset = Quaternion.Euler(-90f, 0f, 90f); //人物軸心跟攝影機不同的話要記得改這邊 看XYZ軸相差多少
            cubeRhand.transform.SetPositionAndRotation(RhandPose.position, RhandPose.rotation * rHandOffset);
            //Debug.Log("右手位置: " + cubeRhand.transform.position + " 旋轉: " + cubeRhand.transform.rotation);
            Vector3 rightAng = cubeRhand.transform.rotation.eulerAngles;
            Debug.Log("右手位置: " + cubeRhand.transform.position + " 旋轉: " + rightAng);
        }
    }
}
