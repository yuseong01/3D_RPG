using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
public class ItemDataSO : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public ItemType itemType;
    public int value; // 공격력,스피드,탐지 및 공격범위 등
}
