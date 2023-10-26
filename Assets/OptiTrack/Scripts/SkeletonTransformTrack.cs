using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonTransformTrack : MonoBehaviour
{
    public Transform head;
    public Transform hip;
    public Transform leftHand;
    public Transform rightHand;
    public Transform leftFoot;
    public Transform rightFoot;

    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        head = animator.GetBoneTransform(HumanBodyBones.Head);
        //hip = animator.GetBoneTransform(HumanBodyBones.Hips);
        leftHand = animator.GetBoneTransform(HumanBodyBones.LeftHand);
        rightHand = animator.GetBoneTransform(HumanBodyBones.RightHand);
        //leftFoot = animator.GetBoneTransform(HumanBodyBones.LeftFoot);
        //rightFoot = animator.GetBoneTransform(HumanBodyBones.RightFoot);

        Debug.Log("1: " + head.position);
        //Debug.Log("2: " + hip.position);
        Debug.Log("3: " + leftHand.position);
        Debug.Log("4: " + rightHand.position);
        //Debug.Log("5: " + leftFoot.position);
        //Debug.Log("6: " + rightFoot.position);
    }
}
