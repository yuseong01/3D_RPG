using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private GameObject uiMainMenu;
    [SerializeField] private GameObject uiStatus;
    [SerializeField] private GameObject uiInventory;
    [SerializeField] private GameObject gameOverPanel;
    
    private UIInventory uiInventoryScript;
    private UIStatus uiStatusScript;
    
    public UIInventory UIInventory => uiInventoryScript;
    public UIStatus UIStatus => uiStatusScript;
    
    private void Awake()
    {
        uiInventoryScript = uiInventory.GetComponent<UIInventory>();
        uiStatusScript = uiStatus.GetComponent<UIStatus>();
    }
    
    public void OpenMainMenu()
    {
        uiMainMenu.SetActive(true);
        uiStatus.SetActive(false);
        uiInventory.SetActive(false);
    }

    public void OpenStatus()
    {
        //uiMainMenu.SetActive(false);
        uiInventory.SetActive(false);
        uiStatus.SetActive(true);
        
        uiStatus.GetComponent<UIStatus>().SetStatus(GameManager.Instance.PlayerStat);
    }

    public void OpenInventory()
    {
        uiStatus.SetActive(false);
        uiInventory.SetActive(true);
        
    }

    public void UpdateGold(int amount)
    {
        uiMainMenu.GetComponent<UIMainMenu>().SetGoldText(amount);
    }
    
    public void ShowGameOver()
    {
        uiStatus.SetActive(false);
        uiInventory.SetActive(false);
        uiMainMenu.SetActive(false);
        
        gameOverPanel.SetActive(true);
        
        Time.timeScale = 0f; 
    }
    
    public void RestartGame()
    {
        Time.timeScale = 1f;
        GameManager.Instance.PlayerStat.CurrentHP = GameManager.Instance.PlayerStat.MaxHP;
        GameManager.Instance.Gold = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
