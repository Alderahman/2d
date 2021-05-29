using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : Interactable
{
    [Header("Contents")]
    public Item contents;
    public bool isOpen;
    public Inventory playerInventory;
    public BoolValue storedOpen;

    [Header("Signal And Dialog")]
    public SignalSender raiseItem;
    public GameObject dialogBox;
    public Text dialogText;

    [Header("Animation")]
    private Animator anim;
    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        isOpen = storedOpen.RunTimeValue;
        if (isOpen)
        {
            anim.SetBool("Opened", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("attack") && playerInRange)
        {
            if (!isOpen)
            {
                //open the chest
                OpenChest();
            }
            else
            {
                //chest is opened
                ChestOpenedAlready();
            }
        }
    }

    public void OpenChest()
    {
        //dialog window open
        dialogBox.SetActive(true);
        //dialog text = context
        dialogText.text = contents.itemDescription;
        //add content to inventory
        playerInventory.AddItem(contents);
        playerInventory.currentItems = contents;
        //raise signal to animate player
        raiseItem.Raise();
        //raise the context clues
        context.Raise();
        //chest opened
        isOpen = true;
        anim.SetBool("Opened", true);
        storedOpen.RunTimeValue = isOpen;
    }

    public void ChestOpenedAlready()
    {
         //disable dialog
        dialogBox.SetActive(false);
        //raise the signal to player stop animate
        raiseItem.Raise();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && !isOpen)
        {
            context.Raise();
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && !isOpen)
        {
            context.Raise();
            playerInRange = false;
        }
    }
}
