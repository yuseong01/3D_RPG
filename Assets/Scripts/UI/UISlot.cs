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
        iconImage.sprite = item.data.icon;
        // countText.text = item.count.ToString();
        
        Button button = GetComponent<Button>();
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        if (item.data.itemType == ItemType.Consumable)
        {
            GameManager.Instance.Player.ApplyConsumableEffect(item);
            Debug.Log($"[Use] Consumable: {item.data.itemName}");
        }
        else
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
        }

        // UI 갱신
        UIManager.Instance.UIInventory.InitInventory(GameManager.Instance.Player.ItemList as List<Item>);
    }
}
