using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonEnemyRoom : DungeonRoom
{
    public List<Door> doors = new List<Door>();


    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            //Activate all enemies and breakable
            for (int i = 0; i < enemies.Count; i++)
            {
                ChangeActivation(enemies[i], true);
            }
            for (int i = 0; i < pots.Count; i++)
            {
                ChangeActivation(pots[i], true);
            }
            CloseDoor();
            virtualCamera.SetActive(true);
        }
    }

    public override void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            //Deactivate all enemies and breakable
            for (int i = 0; i < enemies.Count; i++)
            {
                ChangeActivation(enemies[i], false);
            }
            for (int i = 0; i < pots.Count; i++)
            {
                ChangeActivation(pots[i], false);
            }
            virtualCamera.SetActive(false);
        }
    }

    public void CheckEnemies()
    {
        for(int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i].gameObject.activeInHierarchy)
            {
                return;
            }

            OpenDoor();
        }
    }

    public void CloseDoor()
    {
        for (int i = 0; i < doors.Count; i++)
        {
            doors[i].Close();
        }
    }

    public void OpenDoor()
    {
        for (int i = 0; i < doors.Count; i++)
        {
            doors[i].Open();
        }
    }
}
