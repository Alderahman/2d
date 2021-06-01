using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalInventoryItem : MonoBehaviour
{
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private InventoryItem thisItem;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")|| !other.isTrigger)
        {
            AddItemToInventory();
            Destroy(this.gameObject);
        }
    }


    void AddItemToInventory()
    {
        if(playerInventory && thisItem)
        {
            if (playerInventory.playerInventories.Contains(thisItem))
            {
                thisItem.itemAmount += 1;
            }
            else
            {
                playerInventory.playerInventories.Add(thisItem);
            }
        }
    }
}
