using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{

    [Header("Camera Shaker Config")]
    Vector3 cameraInitialPosition;
    public float ShakeMagnitude = 0.5f;
    public float ShakeTime = 0.5f;
    public Camera mainCamera;

  
    //Vibração da camera
    public void ShakeIt()
    {
        cameraInitialPosition = mainCamera.transform.position;
        InvokeRepeating("StartCameraShaking", 0f, 0.005f);
        Invoke("StopCameraShaking", ShakeTime);
    }

    void StartCameraShaking()//Começa a vibracao
    {
        float cameraShakingOffsetX = Random.value * ShakeMagnitude * 2 - ShakeMagnitude;
        float cameraShakingOffsetY = Random.value * ShakeMagnitude * 2 - ShakeMagnitude;
        Vector3 cameraIntermediatePosition = mainCamera.transform.position;


        cameraIntermediatePosition.x += cameraShakingOffsetX;
        cameraIntermediatePosition.y += cameraShakingOffsetY;
        mainCamera.transform.position = cameraIntermediatePosition;
    }

    void StopCameraShaking()//Para a vibracao
    {
        CancelInvoke("StartCameraShaking");
        mainCamera.transform.position = cameraInitialPosition;
    }
}
