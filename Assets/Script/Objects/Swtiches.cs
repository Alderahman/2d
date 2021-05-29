using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swtiches : MonoBehaviour
{
    public bool active;
    public BoolValue storedValue;
    public Sprite activeSprite;
    private SpriteRenderer mySprite;
    public Door thisDoor;

    // Start is called before the first frame update
    void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
        active = storedValue.RunTimeValue;
        if (active)
        {
            ActiveSwitch();
        }
    }

    public void ActiveSwitch()
    {
        active = true;
        storedValue.RunTimeValue = active;
        thisDoor.Open();
        mySprite.sprite = activeSprite;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ActiveSwitch();
        }
    }
}
