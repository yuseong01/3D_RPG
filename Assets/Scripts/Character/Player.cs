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
    
    public int MaxHP => maxHP;
    public int CurrentHP { get => currentHP; set => currentHP = value; }
    public int AttackDamage => attackDamage;
    public int MoveSpeed => moveSpeed;
    public int AttackRange => attackRange;
    public int DetectRange => detectRange;
}
public class Player : StateMachine
{
    [SerializeField] PlayerStat playerStat;
    
    List<Item> inventory = new List<Item>();
    public IReadOnlyList<Item> Inventory => Inventory;

    private Item equippedWeapon;
    private Item equippedAccessory;

    public ItemDataSO testItem1;
    public ItemDataSO testItem2;
    
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
        
        //테스트용 아이템
        AddItem(testItem1);
        AddItem(testItem2);
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
        inventory.Add(new Item(itemData));
    }

    public void EquipItem(Item item)
    {
        if (!inventory.Contains(item)) return;

        switch (item.data.itemType)
        {
            case ItemType.Weapon:
                equippedWeapon = item;
                break;
            case ItemType.Accessory:
                equippedAccessory = item;
                break;
        }

        item.isEquipped = true;
    }

    public void UnequipItem(Item item)
    {
        if (item == equippedWeapon) equippedWeapon = null;
        if(item == equippedAccessory) equippedAccessory = null;

        item.isEquipped = false;
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
