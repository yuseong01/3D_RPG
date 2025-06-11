using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private GameObject uiMainMenu;
    [SerializeField] private GameObject uiStatus;
    [SerializeField] private GameObject uiInventory;
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
        //uiMainMenu.SetActive(false);
        uiStatus.SetActive(false);
        uiInventory.SetActive(true);
        
    }
}
