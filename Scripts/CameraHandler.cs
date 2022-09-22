using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{

    [SerializeField]
    private CinemachineVirtualCamera _cinemachineVirtualCamera;

    // 当前缩放大小
    private float _orthographicSize;
    // 目标缩放大小
    private float _targetOrthographicSize;

    private void Start()
    {
        _orthographicSize = _cinemachineVirtualCamera.m_Lens.OrthographicSize;
        _targetOrthographicSize = _orthographicSize;
    }

    void Update()
    {
        HandleMovement();
        HandleZoom();
    }

    private void HandleMovement()
    {
        // 摄像机移动
        // 获取移动信息
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = new Vector3(x, y).normalized;
        float moveSpeed = 30f;
        transform.position += moveDir * (moveSpeed * Time.deltaTime);
    }
    
    private void HandleZoom()
    {
         
        // 摄像机放大和缩小

        const float zoomAmount = 2f;
        _targetOrthographicSize += Input.mouseScrollDelta.y * zoomAmount;

        // 最大范围和最小范围
        const float minOrthographicSize = 10;
        const float maxOrthographicSize = 30;
        
        const float zoomSpeed = 2f;
        _targetOrthographicSize = Mathf.Clamp(_targetOrthographicSize, minOrthographicSize, maxOrthographicSize);

        _orthographicSize = Mathf.Lerp(_orthographicSize, _targetOrthographicSize, Time.deltaTime * zoomSpeed);

        _cinemachineVirtualCamera.m_Lens.OrthographicSize = _orthographicSize;
    }
}
