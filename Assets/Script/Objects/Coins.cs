using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : PowerUp
{
    public Inventory playerInventory;

    void Start()
    {
        powerUpSignal.Raise();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            playerInventory.coinsNumber += 1;
            powerUpSignal.Raise();
            Destroy(this.gameObject);
        }
    }
}
