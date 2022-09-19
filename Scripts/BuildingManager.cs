using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{

    private Camera mainCamera;

    [SerializeField]
    [Header("鼠标图片")]
    private GameObject mouseScript;

    // 建筑集合
    private BuildingTypeListSO _buildingTypeList;

    // 当前选择的建筑
    private BuildingTypeSO _buildingType;
    


    private bool _ismouseScriptNotNull;

    // Start is called before the first frame update
    void Start()
    {
        _ismouseScriptNotNull = mouseScript != null;
        mainCamera = Camera.main;
        //  加载资源
        _buildingTypeList = Resources.Load<BuildingTypeListSO>(nameof(BuildingTypeListSO));
       
        _buildingType = _buildingTypeList.list[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (_ismouseScriptNotNull)
        {
            mouseScript.transform.position = GetMouseWorldPosition();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(_buildingType.perfab, GetMouseWorldPosition(), Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log($"T");
            _buildingType = _buildingTypeList.list[0];
        }
        
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Debug.Log($"Y");
            _buildingType = _buildingTypeList.list[1];
        }
        
    }


    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f;
        return mouseWorldPosition;
    }

}
