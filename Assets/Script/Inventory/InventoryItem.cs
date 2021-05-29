using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class InventoryItem : ScriptableObject
{
    public string itemName;
    public string ItemDescription;
    public Sprite itemImage;
    public int itemAmount;
    public bool useable;
    public bool unique;
    public UnityEvent thisEvent;

    public void UseItem()
    {

        thisEvent.Invoke();
    }

    public void decreaseAmount(int amountToDecrease)
    {
        itemAmount-= itemAmount;
        if(itemAmount < 0)
        {
            itemAmount = 0;
        }
    }
}
