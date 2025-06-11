using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private Player player;
    [SerializeField] private PlayerStat playerStat;
    [SerializeField] private int gold = 0;
    public int Gold {
        get => gold;
        set
        {
            gold = value;
            UIManager.Instance?.UpdateGold(gold); // UI 반영
        }
        
    }
    
    public Player Player => player;
    public PlayerStat PlayerStat => playerStat;

    protected override void Awake()
    {
        base.Awake();

        if (player == null)
        {
            player = FindObjectOfType<Player>();
            playerStat = player.GetComponent<PlayerStat>();
        }

        playerStat = player.Stat;
        
        UIManager.Instance.OpenMainMenu();
    }
}
