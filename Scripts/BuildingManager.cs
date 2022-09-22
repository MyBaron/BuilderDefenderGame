using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingManager : MonoBehaviour
{

    public static BuildingManager Instance { get; private set; }
    
    private Camera mainCamera;

    [SerializeField]
    [Header("鼠标图片")]
    private GameObject mouseScript;

    // 建筑集合
    private BuildingTypeListSO _buildingTypeList;

    // 当前选择的建筑
    private BuildingTypeSO _activeBuildingType;
    
    private bool _ismouseScriptNotNull;

    private void Awake()
    {
        Instance = this;
        //  加载资源
        _buildingTypeList = Resources.Load<BuildingTypeListSO>(nameof(BuildingTypeListSO));
    }

    // Start is called before the first frame update
    void Start()
    {
        _ismouseScriptNotNull = mouseScript != null;
        mainCamera = Camera.main;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (_ismouseScriptNotNull)
        {
            mouseScript.transform.position = GetMouseWorldPosition();
        }

        // 并且不在 UI上
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            if (_activeBuildingType != null)
            {
                Instantiate(_activeBuildingType.perfab, GetMouseWorldPosition(), Quaternion.identity);
            }
        }
    }

    /*
     * 设置当前选择的建筑
     */
    public void SetActiveBuildingType(BuildingTypeSO buildingTypeSo)
    {
        _activeBuildingType = buildingTypeSo;
    }

    /*
     * 获取当前选择的建筑
     */
    public BuildingTypeSO GetActiveBuildingType()
    {
        return _activeBuildingType;
    }


    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f;
        return mouseWorldPosition;
    }

}
