using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]

//for creating a signal with parameter in it
public class FloatEvent: UnityEvent<float> { }
public class FloatSignalListener : MonoBehaviour
{
    public FloatSignal signal;
    public FloatEvent signalEventFloat;

    //can put one or more parameter but need create different scirpt for different parameter
    public void OnSignalRaised(float value) => this.signalEventFloat.Invoke(value);

    private void OnEnable()
    {
        signal.RegisterListener(this);
    }

    private void OnDisable()
    {
        signal.DeRegisterListener(this);
    }
}
