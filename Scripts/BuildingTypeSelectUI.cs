using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingTypeSelectUI : MonoBehaviour
{
    [SerializeField]
    private Sprite arrowSprite;
    private Dictionary<BuildingTypeSO, Transform> _btnTransformDictionary = new Dictionary<BuildingTypeSO, Transform>();

    private Transform _arrowBtn;


    private void Awake()
    { 
        // 获取模板对象
        var btnTemplate = transform.Find("BtnTemplate");
        btnTemplate.gameObject.SetActive(false);
        
        // 加载所有建筑
        var buildingTypeList = Resources.Load<BuildingTypeListSO>(nameof(BuildingTypeListSO));
        InitArrowBtn(btnTemplate);

        int index = 1;
        foreach (var buildingType in buildingTypeList.list)
        {
            // 创建对象
            var btnTransform = Instantiate(btnTemplate, transform);
            btnTransform.gameObject.SetActive(true);

            float offsetAmount = 130f;
            btnTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(offsetAmount * index, 0);

            btnTransform.Find("Image").GetComponent<Image>().sprite = buildingType.sprite;
            
            // 设置按钮事件
            btnTransform.GetComponent<Button>().onClick.AddListener(() =>
            {
                BuildingManager.Instance.SetActiveBuildingType(buildingType);
            });

            _btnTransformDictionary[buildingType] = btnTransform;
            
            index++;
        }
    }
    

    private void Update()
    {
        UpdateActiveBuildingTypeButton();
    }



    private void InitArrowBtn(Transform btnTemplate)
    {
        // 创建对象
        var btnTransform = Instantiate(btnTemplate, transform);
        btnTransform.gameObject.SetActive(true);

        float offsetAmount = 130f;
        btnTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(0 , 0);

        btnTransform.Find("Image").GetComponent<Image>().sprite = arrowSprite;
        btnTransform.Find("Image").GetComponent<RectTransform>().sizeDelta = new Vector2(50, 50);
        _arrowBtn = btnTransform;
    }
    
    private void UpdateActiveBuildingTypeButton()
    {
        _arrowBtn.Find("Selected").gameObject.SetActive(false);
        foreach (var buildingType in _btnTransformDictionary.Keys)
        {
            var btnTransform =  _btnTransformDictionary[buildingType];
            btnTransform.Find("Selected").gameObject.SetActive(false);
        }

        var activeBuildingType = BuildingManager.Instance.GetActiveBuildingType();
        if (activeBuildingType == null)
        {
            _arrowBtn.Find("Selected").gameObject.SetActive(true);
        }
        else
        {
            _btnTransformDictionary[activeBuildingType].Find("Selected").gameObject.SetActive(true);
        }
    }
}
