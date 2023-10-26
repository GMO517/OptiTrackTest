using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGenerate : MonoBehaviour
{
    public GameObject characterPrefab;
    public Avatar charactorAvatar;
    public Transform root;
    OptitrackSkeletonAnimator optiCharacter;
    SkeletonTransform skeletonTransform;
    void Start()
    {
        // 實例化人物模型
        GameObject model = Instantiate(characterPrefab);
        model.transform.SetParent(root);
        // 附加腳本組件到人物模型
        optiCharacter = model.AddComponent<OptitrackSkeletonAnimator>();
        model.AddComponent<SkeletonTransform>();
        //todo 做到這邊 準備加上抓取定位腳本
        // 更改腳本中的SkeletonName值 & Avator
        optiCharacter.SkeletonAssetName = "Skeleton001";
        optiCharacter.DestinationAvatar = charactorAvatar;

    }
}
