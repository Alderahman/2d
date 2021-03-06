using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public List<Enemy> enemies =  new List<Enemy>();
    public List<Pot> pots = new List<Pot>();
    public GameObject virtualCamera;

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            //Activate all enemies and breakable
            for (int i = 0; i < enemies.Count; i++)
            {
                ChangeActivation(enemies[i], true);
            }
            for(int i = 0; i< pots.Count; i++)
            {
                ChangeActivation(pots[i], true);
            }
            virtualCamera.SetActive(true);
        }
    }

    public virtual void OnTriggerExit2D(Collider2D other)
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

    public void ChangeActivation(Component component,bool activation)
    {
        component.gameObject.SetActive(activation);
    }
}
