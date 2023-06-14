using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BackgroundScaler : MonoBehaviour
{
    public Camera mainCamera;
    public Transform backgroundObject;

    private void Start()
    {
        //메인카메라
        float cameraAspectRatio = mainCamera.aspect;

        // 백 그라운드
        float backgroundAspectRatio = backgroundObject.localScale.x / backgroundObject.localScale.y;

        if (cameraAspectRatio > backgroundAspectRatio)
        {
            //수평적용
            float scaleRatio = cameraAspectRatio / backgroundAspectRatio;
            backgroundObject.localScale = new Vector3(scaleRatio, 1f, 1f);
        }
        else
        {
            //수직적용
            float scaleRatio = backgroundAspectRatio / cameraAspectRatio;
            backgroundObject.localScale = new Vector3(1f, scaleRatio, 1f);
        }
    }
}
