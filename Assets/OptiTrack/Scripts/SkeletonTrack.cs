using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonTrack : MonoBehaviour
{
    public Transform trackHead;
    public Transform trackHip;
    public Transform trackLeftHand;
    public Transform trackRightHand;
    public Transform trackLeftFoot;
    public Transform trackRightFoot;

    //public Animator animator;

    //public GameObject followHead;
    //public GameObject followLHand;
    //public GameObject followRHand;

    //public Transform poseTrans;

    void Start()
    {
        //animator = GetComponent<Animator>();
        GetBoneTransform();
    }
    void Update()
    {
        //GetBoneTransform();
        //Debug.Log("位置: " + trackHead.position);
        //Debug.Log("位置2: " + trackHead.transform.position);

        //Debug.Log("旋轉: " + trackHead.rotation);
        //Debug.Log("旋轉: " + trackHead.transform.rotation);


    }

    private void GetBoneTransform()
    {
        //trackHead = animator.GetBoneTransform(HumanBodyBones.Head);
        //trackHip = animator.GetBoneTransform(HumanBodyBones.Hips);
        //trackLeftHand = animator.GetBoneTransform(HumanBodyBones.LeftHand);
        //trackRightHand = animator.GetBoneTransform(HumanBodyBones.RightHand);
        //trackLeftFoot = animator.GetBoneTransform(HumanBodyBones.LeftFoot);
        //trackRightFoot = animator.GetBoneTransform(HumanBodyBones.RightFoot);
    }

    public void GetPose()
    {
        //poseTrans = trackHead.transform;
    }


}
