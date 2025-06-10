using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Transform contentTransform; // ScrollView의 Content
    
    private List<UISlot> slotList = new List<UISlot>();

    public void InitInventory(List<ItemDataSO> items)
    {
        foreach( Transform child in contentTransform)
            Destroy(child.gameObject);

        foreach (ItemDataSO item in items)
        {
            GameObject slotGO = Instantiate(slotPrefab, contentTransform);
            UISlot slot = slotGO.GetComponent<UISlot>();
            slot.SetItem(item);
            slotList.Add(slot);
        }
    }
    
    
}
