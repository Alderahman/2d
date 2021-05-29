using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicPowerUp : PowerUp
{
    public Inventory inventory;
    public float magicValue;
    public FloatValue currentMagic;
    public FloatValue maxMagic;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")&& !other.isTrigger)
        {
            currentMagic.RunTimeValue += magicValue;
            if(currentMagic.RunTimeValue > maxMagic.RunTimeValue)
            {
                currentMagic.RunTimeValue = maxMagic.RunTimeValue;
            }
            powerUpSignal.Raise();
            Destroy(this.gameObject);
        }
    }
}
