using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private GameObject uiMainMenu;
    [SerializeField] private GameObject uiStatus;
    [SerializeField] private GameObject uiInventory;
    private UIInventory uiInventoryScript;
    
    public UIInventory UIInventory => uiInventoryScript;
    
    private void Awake()
    {
        uiInventoryScript = uiInventory.GetComponent<UIInventory>();
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
        uiStatus.SetActive(true);
        
        uiStatus.GetComponent<UIStatus>().SetStatus(GameManager.Instance.PlayerStat);
    }

    public void OpenInventory()
    {
        uiMainMenu.SetActive(false);
        uiInventory.SetActive(true);
    }
}
