using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/BuildingType")]
public class BuildingTypeSO : ScriptableObject
{
    [Header("建筑名称")]
    public string buildingName;
    [Header("预制体")]
    public Transform perfab;
}
