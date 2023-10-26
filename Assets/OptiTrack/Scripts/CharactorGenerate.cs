using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorGenerate : MonoBehaviour
{
    public GameObject charactor;
    public Avatar charactorAvatar;
    public Transform root;
    OptitrackSkeletonAnimator skePosScript;

    void Start()
    {
        // 實例化人物模型
        GameObject rebel = Instantiate(charactor);

        rebel.transform.SetParent(root);
        // 附加腳本組件到人物模型
        //skePosScript = OptitrackSkeletonAnimator skeletonTransformTrack;
        skePosScript = rebel.AddComponent<OptitrackSkeletonAnimator>();

        // 更改腳本中的skeletonName值
        skePosScript.SkeletonAssetName = "Skeleton001";
        skePosScript.DestinationAvatar = charactorAvatar;

    }
}
