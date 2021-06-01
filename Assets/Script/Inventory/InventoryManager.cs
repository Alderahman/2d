using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    [Header("Inventory Information")]
    public PlayerInventory playerInventory;
    [SerializeField] private GameObject blankInventorySlot;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private TextMeshProUGUI itemDescriptionText;
    [SerializeField] private GameObject useButton;
    public InventoryItem currentItem;

    public void SetTextAndButton(string description, bool buttonActive)
    {
        itemDescriptionText.text = description;

        if (buttonActive)
        {
            useButton.SetActive(true);
        }
        else
        {
            useButton.SetActive(false);
        }
    }

    void MakeInventorySlot()
    {
        if (playerInventory)
        {
            for (int i = 0; i < playerInventory.playerInventories.Count; i++)
            {
                if (playerInventory.playerInventories[i].itemAmount > 0 || playerInventory.playerInventories[i].itemName == "Bottle")
                {
                    GameObject temp = Instantiate(blankInventorySlot, inventoryPanel.transform.position, Quaternion.identity);
                    temp.transform.SetParent(inventoryPanel.transform);
                    InventorySlot newSlot = temp.GetComponent<InventorySlot>();
                    if (newSlot)
                    {
                        newSlot.Setup(playerInventory.playerInventories[i], this);
                    }
                }
            }
        }
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        ClearInventorySlot();
        MakeInventorySlot();
        SetTextAndButton("", false);
    }

    private void Update()
    {
        
    }

    public void SetupDescriptionAndButton(string newDescriptionText, bool isButtonUsable, InventoryItem newItem)
    {
        currentItem = newItem;
        itemDescriptionText.text = newDescriptionText;
        useButton.SetActive(isButtonUsable);
    }

    void ClearInventorySlot()
    {
        for(int i=0; i<inventoryPanel.transform.childCount; i++)
        {
            Destroy(inventoryPanel.transform.GetChild(i).gameObject);
        }
    }

    public void UseItemPressed()
    {
        if (currentItem)
        {
            currentItem.UseItem(); 
            //clear all the inventory slot
            ClearInventorySlot();
            //refill the inventory slot with number
            MakeInventorySlot();
            if(currentItem.itemAmount == 0)
            {
                SetTextAndButton("", false);
            }
            
        }
    }
}
