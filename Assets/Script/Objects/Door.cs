using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorType
{
    key,
    enemy,
    button
}

public class Door : Interactable
{
    [Header("Door Variables")]
    public DoorType thisDoorType;
    public bool open = false;
    public Inventory playerInventory;
    public SpriteRenderer doorSprite;
    public BoxCollider2D physicsCollider;
    public GameObject doorTriggerArea;

    private void Start()
    {
        doorTriggerArea.SetActive(true);
    }

    private void Update()
    {
        
        if (Input.GetButtonDown("attack"))
        {
            if (playerInRange && thisDoorType == DoorType.key)
            {
                //check if the player have key
                if(playerInventory.numberOfKeys > 0)
                {
                    //rid player key by 1
                    playerInventory.numberOfKeys--;
                    //open the door
                    Open();
                }
            }
        }
    }
    public void Open()
    {
        //turn off the sprite renderer
        doorSprite.enabled = false;
        //set open true
        open = true;
        //turn off the box collider
        physicsCollider.enabled = false;
        doorTriggerArea.SetActive(false);
    }

    public void Close()
    {
        //turn off the sprite renderer
        doorSprite.enabled = true;
        //set open true
        open = false;
        //turn off the box collider
        physicsCollider.enabled = enabled;
    }
}
