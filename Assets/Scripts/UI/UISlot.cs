using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    [SerializeField] private TMP_Text countText;
    
    private ItemDataSO itemData;

    public void SetItem(ItemDataSO item)
    {
        itemData = item;
        iconImage.sprite = item.icon;
        // countText.text = item.count.ToString();
    }

    public void OnClick()
    {
        Debug.Log($"Clicked item: {itemData.itemName}");
        // TODO: 장착/해제 로직
    }
}
