using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    [Header("Heart Spirte")]
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite halfFullHeart;
    public Sprite emptyHeart;

    [Header("Player Hearts")]
    public FloatValue heartContainers;
    public FloatValue playerCurrentHealth;

    // Start is called before the first frame update
    void Start()
    {
        InitHearts();
    }

    public void InitHearts()
    {
        for (int i = 0; i < heartContainers.initialValue; i++)
        {
            if (i < hearts.Length)
            {
                hearts[i].gameObject.SetActive(true);
                hearts[i].sprite = fullHeart;
            }
        }
    }

    public void UpdateHeart()
    {
        float tempHealth = playerCurrentHealth.RunTimeValue / 2;
        for (int i = 0; i<heartContainers.initialValue; i++)
        {
            if(i<= tempHealth-1)
            {
                hearts[i].sprite = fullHeart;
                //full heart
            }
            else if (i >= tempHealth)
            {
                hearts[i].sprite = emptyHeart;
                //empty heart
            }
            else
            {
                hearts[i].sprite = halfFullHeart;
                //half full heart
            }
        }
    }
}
