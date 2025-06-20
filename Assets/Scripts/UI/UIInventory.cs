using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    [SerializeField] Button closeButton;
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Transform contentTransform; // ScrollView의 Content
    [SerializeField] private TMP_Text inventoryNumberText;
    [SerializeField] private int maxInventoryCount = 120;
    
    private List<UISlot> slotList = new List<UISlot>();

    public void InitInventory(List<Item> items)
    {
        //기존 슬롯 제거
        foreach( Transform child in contentTransform)
            Destroy(child.gameObject);
        slotList.Clear();

        //새로운 슬롯 생성
        foreach (Item item in items)
        {
            GameObject slotGO = Instantiate(slotPrefab, contentTransform);
            UISlot slot = slotGO.GetComponent<UISlot>();
            slot.SetItem(item);
            slotList.Add(slot);
        }
        
        inventoryNumberText.text = $"{items.Count}/{maxInventoryCount}";
    }
    
    private void Start()
    {
        closeButton.onClick.AddListener(() => UIManager.Instance.OpenMainMenu());
    }
}
