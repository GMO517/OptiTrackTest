using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreenController : MonoBehaviour
{

    public bool isScreenFull = false;


    public void SwitchToFullScreen()
    {
        //還不能用 需要調整
        if (!isScreenFull)
        {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
            Screen.fullScreen = true;
            isScreenFull = true;

        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
            Screen.fullScreen = false;
            isScreenFull = false;

        }
    }
}

