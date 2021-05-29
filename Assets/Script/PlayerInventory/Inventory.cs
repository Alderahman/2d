using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class Inventory : ScriptableObject
{
    public Item currentItems;
    public List<Item> items = new List<Item>();
    public int numberOfKeys;
    public int coinsNumber;
    

    public bool CheckForItem(Item item)
    {
        if (items.Contains(item))
        {
            return true;
        }
        return false;
    }

    public void AddItem(Item itemToAdd)
    {
        //if keys
        if (itemToAdd.isKey)
        {
            numberOfKeys++;
        }
        //if not keys
        else
        {
            //add item to inventory
            if (!items.Contains(itemToAdd))
            {
                items.Add(itemToAdd);
            }
        }
    }
}
