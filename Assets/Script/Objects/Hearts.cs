using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearts : PowerUp
{
    [Header("Player Heart")]
    public FloatValue playerHealth;
    public FloatValue heartContainers;
    [Header("Heal Player")]
    public float amountToIncrease;
    

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            playerHealth.RunTimeValue += amountToIncrease;
            if (playerHealth.RunTimeValue > heartContainers.RunTimeValue * 2f)
            {
                playerHealth.RunTimeValue = heartContainers.RunTimeValue * 2f;
            }
            powerUpSignal.Raise();
            Destroy(this.gameObject);
        }
    }
}
