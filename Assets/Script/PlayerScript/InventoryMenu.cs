using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenu : MonoBehaviour
{
    public GameObject inventoryPanel;
    private bool isPause;

    // Start is called before the first frame update
    void Start()
    {
        isPause = false;
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetButtonDown("inventory menu"))
        {
            InventoryActive();
        }
    }

    public void InventoryActive()
    {
        isPause = !isPause;
        if (isPause)
        {
            inventoryPanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            inventoryPanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
