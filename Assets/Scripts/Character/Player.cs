using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[System.Serializable]
public class PlayerStat
{
    [Header("Player Stat")]
    [SerializeField] private int maxHP = 50;
    [SerializeField] private int currentHP;
    [SerializeField] private int attackDamage = 10;
    [SerializeField] private int moveSpeed = 3;
    [SerializeField] private int attackRange = 2;
    [SerializeField] private int detectRange = 5;
    
    private int bonusAttackRange = 0;
    private int bonusDetectRange = 0;
    private int bonusMoveSpeed = 0;
    private int bonusAttackDamage = 0;
    private int bonusHp = 0;
    
    public int MaxHP => maxHP;
    public int CurrentHP { get => currentHP+bonusHp; set => currentHP = value; }

    public int AttackDamage => attackDamage + bonusAttackDamage;
    public int MoveSpeed => moveSpeed + bonusMoveSpeed;
    public int AttackRange => attackRange + bonusAttackRange;
    public int DetectRange => detectRange + bonusDetectRange;
    
    public int BaseAttackRange => attackRange;
    public int BonusAttackRange { get => bonusAttackRange; set => bonusAttackRange = value; }
    public int BaseDetectRange => detectRange;
    public int BonusDetectRange { get => bonusDetectRange; set => bonusDetectRange = value; }
    public int BaseMoveSpeed => moveSpeed;
    public int BonusMoveSpeed { get => bonusMoveSpeed; set => bonusMoveSpeed = value; }
    public int BaseAttackDamage => attackDamage;
    public int BonusAttackDamage { get => bonusAttackDamage; set => bonusAttackDamage = value; }
    
    public void IncreaseDetectRange(int amount)
    {
        detectRange += amount;
        Debug.Log($"[Effect] 탐지 범위 +{amount} → 현재: {detectRange}");
    }

    public void IncreaseAttackRange(int amount)
    {
        attackRange += amount;
        Debug.Log($"[Effect] 공격 범위 +{amount} → 현재: {attackRange}");
    }

    public void IncreaseMoveSpeed(int amount)
    {
        moveSpeed += amount;
        Debug.Log($"[Effect] 이동속도 +{amount} → 현재: {moveSpeed}");
    }
    
    public void IncreaseAttackDamage(int amount)
    {
        attackDamage += amount;
        Debug.Log($"[Effect] 공격데미지 +{amount} → 현재: {attackDamage}");
    }
}
public class Player : StateMachine
{
    [SerializeField] PlayerStat playerStat;
    public PlayerStat Stat => playerStat;

    
    [SerializeField] private List<ItemDataSO> initialItemDataList;
    List<Item> itemList = new List<Item>();
    
    public IReadOnlyList<Item> ItemList => itemList;

    private Item equippedWeapon;
    private Item equippedAccessory;
    
    private NavMeshAgent agent;
    
    public NavMeshAgent Agent => agent;
    public Transform CachedTransform { get; private set; }

    [HideInInspector] public PlayerMoveState moveState;
    [HideInInspector] public PlayerAttackState attackState;

    private void Awake()
    {
        CachedTransform = transform;
    }
    public void Start()
    {
        playerStat.CurrentHP = playerStat.MaxHP;
        
        agent = GetComponent<NavMeshAgent>();
        agent.speed = playerStat.MoveSpeed;
        
        moveState = new PlayerMoveState(this, playerStat);
        attackState = new PlayerAttackState(this, playerStat);
        
        ChangeState(moveState);

        foreach (var data in initialItemDataList)
        {
            itemList.Add(new Item(data));
        }
        
        UIManager.Instance.UIInventory.InitInventory(itemList);
    }
    
    public void TakeDamage(int damage)
    {
        playerStat.CurrentHP -= damage;
        
        if (playerStat.CurrentHP <= 0)
        {
            Die();
        }
    }

    public void AddItem(ItemDataSO itemData)
    {
        itemList.Add(new Item(itemData));
    }

    public void EquipItem(Item item)
    {
        if (!itemList.Contains(item)) return;

        switch (item.data.itemType)
        {
            case ItemType.Weapon:
                equippedWeapon = item;
                playerStat.BonusAttackDamage += item.data.value;
                break;
            case ItemType.Accessory:
                equippedAccessory = item;
                playerStat.BonusMoveSpeed += item.data.value;
                break;
        }

        item.isEquipped = true;
    }

    public void UnequipItem(Item item)
    {
        if (item == equippedWeapon)
        {
            playerStat.BonusAttackDamage -= item.data.value;
            equippedWeapon = null;
        }

        if (item == equippedAccessory)
        {
            playerStat.BonusMoveSpeed -= item.data.value;
            equippedAccessory = null;
        }

        item.isEquipped = false;
    }
    
    public void ApplyConsumableEffect(Item item)
    {
        if (item.data.itemType != ItemType.Consumable) return;

        switch (item.data.itemName)
        {
            case "DetectPotion":
                playerStat.BonusDetectRange += item.data.value;
                playerStat.IncreaseDetectRange(item.data.value);
                break;
            case "AttackRangePotion":
                playerStat.BonusAttackRange += item.data.value;
                playerStat.IncreaseAttackRange(item.data.value);
                break;
            default:
                Debug.LogWarning($"알 수 없는 consumable: {item.data.itemName}");
                break;
        }

        itemList.Remove(item);
    }
    
    

    private void Die()
    {
        Debug.Log("Player Dead");
        Destroy(gameObject);
        //게임오버
    }
    
    private void OnDrawGizmos()
    {
        // 감지 범위 (빨간색 원)
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, playerStat.DetectRange);

        // 공격 범위 (노란색 원)
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, playerStat.AttackRange);
    }

}
