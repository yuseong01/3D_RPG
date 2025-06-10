using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private Button statusButton;
    [SerializeField] private Button inventoryButton;
    
    void Start()
    {
        statusButton.onClick.AddListener(OnStatusButtonClick);
        inventoryButton.onClick.AddListener(OnInventoryButtonClick);
    }

    private void OnStatusButtonClick()
    {
        UIManager.Instance.OpenStatus();
    }

    private void OnInventoryButtonClick()
    {
        UIManager.Instance.OpenInventory();
    }
}
