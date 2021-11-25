using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    private PlayerController playerTarget;

    private CinemachineVirtualCamera virtualCam;

    // Start is called before the first frame update
    void Awake()
    {
        playerTarget = FindObjectOfType<PlayerController>();

        virtualCam = GetComponent<CinemachineVirtualCamera>();

        virtualCam.Follow = playerTarget.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
