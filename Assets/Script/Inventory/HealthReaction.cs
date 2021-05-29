using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthReaction : MonoBehaviour
{
    public FloatValue playerHealth;
    public FloatValue heartContainers;
    public SignalSender healthSignal;

    public void Use(int amountToIncrease)
    {
        playerHealth.RunTimeValue += amountToIncrease;
        if (playerHealth.RunTimeValue > heartContainers.RunTimeValue * 2f)
        {
            playerHealth.RunTimeValue = heartContainers.RunTimeValue * 2f;
        }
        healthSignal.Raise();
    }
}
