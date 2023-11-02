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

    private OptitrackSkeletonAnimator skeletonScript;
    private void Start()
    {
        skeletonScript = this.GetComponent<OptitrackSkeletonAnimator>();
    }


}
