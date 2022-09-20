using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 资源生成器
 */
public class ResourceGenerator : MonoBehaviour
{
    // 当前时间
    private float timer;
    // 间隔时间
    private float timerMax;

    // 资源类型
    private BuildingTypeSO _buildingTypeSo;

    private void Awake()
    {
        _buildingTypeSo = GetComponent<BuildingTypeHolder>().buildingTypeSo;
        timerMax = _buildingTypeSo.resourceGeneratorData.timerMax;
        
    }


    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer += timerMax;
            Debug.Log($"generator: {_buildingTypeSo.resourceGeneratorData.resourceType.name}");
            ResourceManager.Instance.addResource(_buildingTypeSo.resourceGeneratorData.resourceType, 1);
            
        }
    }
}
