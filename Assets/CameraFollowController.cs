using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowController : MonoBehaviour
{
    public CinemachineFreeLook _camera;
    void Start()
    {
        _camera = GetComponent<CinemachineFreeLook>();
    }
    private void Update()
    {
        _camera.LookAt = PlayerManager.currentPlayer.gameObject.transform;
        
    }


}
