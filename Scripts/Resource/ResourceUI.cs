using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourceUI : MonoBehaviour
{
   private ResourceTypeListSO _resourceTypeList;

   private Dictionary<ResourceTypeSO, Transform> resourceTypeTransformDictionary = new Dictionary<ResourceTypeSO, Transform>();


   private void Awake()
   {
      // 获取所有资源类型
      _resourceTypeList = Resources.Load<ResourceTypeListSO>(nameof(ResourceTypeListSO));
      
      //找到子对象
      var resourceTemplate = transform.Find("ResourceTemplate");
      resourceTemplate.gameObject.SetActive(false);

      // 循环创建模板
      int index = 0;
      foreach (var resourceType in _resourceTypeList.list)
      {
         // 创建模板
         var resourceTransform = Instantiate(resourceTemplate, transform);
         resourceTransform.gameObject.SetActive(true);

         // 位置偏移量
         float offsetAmount = -150f;
         
         resourceTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(offsetAmount * index, 0);
         resourceTransform.Find("Image").GetComponent<Image>().sprite = resourceType.sprite;
         resourceTypeTransformDictionary[resourceType] = resourceTransform;
         
         index++;
      }
   }

   private void Start()
   {
      ResourceManager.Instance.OnResourceAmountChanged += ResourceManager_OnResourceAmountChanged;
      UpdateResourceAmount();
   }

   private void ResourceManager_OnResourceAmountChanged(object sender, EventArgs e)
   {
      UpdateResourceAmount();
   }

   private void UpdateResourceAmount()
   {
      foreach (var resourceType in _resourceTypeList.list)
      {
         var  resourceTransform = resourceTypeTransformDictionary[resourceType];
         var amount = ResourceManager.Instance.GetResourceAmount(resourceType);
         resourceTransform.Find("Text").GetComponent<TextMeshProUGUI>().SetText(amount.ToString());
      }
   }
}
