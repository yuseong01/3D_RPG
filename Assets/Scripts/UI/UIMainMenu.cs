using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private Button statusButton;
    [SerializeField] private Button inventoryButton;
    
    [SerializeField] private TMP_Text nicknameText;
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private TMP_Text descriptionText;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private TMP_Text goldText;

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
