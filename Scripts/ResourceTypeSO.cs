using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/ResourceType")]
public class ResourceTypeSO : ScriptableObject
{
    [Header("资源名称")]
    public string resourceName;

    [Header("图片")]
    public Sprite sprite;
}
