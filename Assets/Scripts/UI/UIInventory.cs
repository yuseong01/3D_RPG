using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    [SerializeField] Button closeButton;
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Transform contentTransform; // ScrollView의 Content
    
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
    }
    
    private void Start()
    {
        closeButton.onClick.AddListener(() => UIManager.Instance.OpenMainMenu());
    }
}
