using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance
    {
        get; private set;
    }
    
    /*
     * 资源数量变更事件
     */
    public event EventHandler OnResourceAmountChanged;
    
    private Dictionary<ResourceTypeSO, int> _resourceAmountDictionary;

    private void Awake()
    {
        Instance = this;
        _resourceAmountDictionary = new Dictionary<ResourceTypeSO, int>();

        var resourceTypeListSo = Resources.Load<ResourceTypeListSO>(nameof(ResourceTypeListSO));
        foreach (var resourceTypeSo in resourceTypeListSo.list)
        {
            // 初始化每一个资源
            _resourceAmountDictionary[resourceTypeSo] = 0;
        }
        
    }

    /*
     * 添加资源数量
     */
    public void addResource(ResourceTypeSO resourceTypeSo, int amount)
    {
        OnResourceAmountChanged?.Invoke(this,EventArgs.Empty);
        _resourceAmountDictionary[resourceTypeSo] += amount;
    }

    /*
     * 获取资源数量
     */
    public int GetResourceAmount(ResourceTypeSO resourceTypeSo)
    {
        return _resourceAmountDictionary[resourceTypeSo];
    }
}
