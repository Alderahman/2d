using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Loot
{
    public PowerUp thisLoot;
    public float lootChance;
}

[CreateAssetMenu]
public class LootTable : ScriptableObject
{
    public Loot[] loots;

    public PowerUp LootPowerUp()
    {
        float cumulativeProbailities = 0;
        float currentProbabilities = Random.Range(0, 100);
        for(int i = 0; i < loots.Length; i++)
        {
            cumulativeProbailities += loots[i].lootChance;
            if (currentProbabilities <= cumulativeProbailities)
            {
                return loots[i].thisLoot;
            }
        }
        return null;
    }
}
