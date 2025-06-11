using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public ItemDataSO data;
    public bool isEquipped;

    public Item(ItemDataSO data)
    {
        this.data = data;
        isEquipped = false;
    }
}
