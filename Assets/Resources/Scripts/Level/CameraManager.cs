using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CameraManager : Common.MonoSingleton<CameraManager>
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    public CinemachineVirtualCamera VirtualCamera => virtualCamera;
    [SerializeField] private Camera cam;
    private void Start()
    {
        if (cam == null) cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        cam.GetUniversalAdditionalCameraData().cameraStack.Add(GameManager.Instance.Camera);
    }
}
