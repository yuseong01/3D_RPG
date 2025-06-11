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
    private PlayerStat stat;
    
    void Start()
    {
        stat = GameManager.Instance.PlayerStat;
        nicknameText.text = "YUSEONG";
        descriptionText.text = "I love chicken";
        
        statusButton.onClick.AddListener(OnStatusButtonClick);
        inventoryButton.onClick.AddListener(OnInventoryButtonClick);
    }

    void Update()
    {
        levelText.text = "1";   //나중에 레벨 연계시스템
        goldText.text = GameManager.Instance.Gold.ToString();
        
        healthSlider.maxValue = stat.MaxHP;
        healthSlider.value = stat.CurrentHP;
    }

    private void OnStatusButtonClick()
    {
        UIManager.Instance.OpenStatus();
    }

    private void OnInventoryButtonClick()
    {
        UIManager.Instance.OpenInventory();
    }
    
    public void SetGoldText(int amount)
    {
        goldText.text=amount.ToString();
    }
}
