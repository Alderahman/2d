using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicManagement : MonoBehaviour
{
    public Slider magicSlider;
    public FloatValue currentMagic;
    public FloatValue maxMagic;

    private void OnEnable()
    {
        currentMagic.RunTimeValue = maxMagic.RunTimeValue;
    }

    // Start is called before the first frame update
    void Start()
    {
        magicSlider.maxValue = maxMagic.RunTimeValue;
        magicSlider.value = maxMagic.RunTimeValue;
        currentMagic.RunTimeValue = maxMagic.RunTimeValue;
    }

    public void RestoreMagic()
    {
        magicSlider.value = currentMagic.RunTimeValue;
        if (magicSlider.value > magicSlider.maxValue)
        {
            magicSlider.value = magicSlider.maxValue;
            currentMagic.RunTimeValue = maxMagic.RunTimeValue;
        }
    }

    public void ConsumeMagic()
    {
        //magicSlider.value -= 1;
        //playerInventory.currentMagic -= 1;
        magicSlider.value = currentMagic.RunTimeValue;
        if (magicSlider.value < 0)
        {
            magicSlider.value = 0;
            currentMagic.RunTimeValue = 0;
        }
    }

    public void ReduceMagic(float magicCost) => currentMagic.RunTimeValue -= magicCost;
}
