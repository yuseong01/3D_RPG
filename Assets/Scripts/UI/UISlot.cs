using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    //[SerializeField] private TMP_Text countText;
    
    private Item item;

    public void SetItem(Item item)
    {
        this.item = item;
        
        if (item == null || item.data == null)
        {
            Debug.LogError("❌ Item 또는 Item.data가 null입니다!");
            return;
        }
        if (iconImage == null)
        {
            Debug.LogError("❌ iconImage가 에디터에서 연결되지 않았습니다!");
            return;
        }
        
        iconImage.sprite = item.data.icon;
        // countText.text = item.count.ToString();
    }

    public void OnClick()
    {
        if (item.isEquipped)
        {
            GameManager.Instance.Player.UnequipItem(item);
            Debug.Log($"Unequipped: {item.data.itemName}");
        }
        else
        {
            GameManager.Instance.Player.EquipItem(item);
            Debug.Log($"Equipped: {item.data.itemName}");
        }

        // UI 갱신
        UIManager.Instance.UIInventory.InitInventory(GameManager.Instance.Player.ItemList as List<Item>);
    }
}
