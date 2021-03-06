using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Signal/FloatSignal")]
public class FloatSignal : ScriptableObject
{
    public List<FloatSignalListener> listeners = new List<FloatSignalListener>();

    public void Raise(float value)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            this.listeners[i].OnSignalRaised(value);
        }
    }

    public void RegisterListener(FloatSignalListener listener)
    {
        listeners.Add(listener);
    }

    public void DeRegisterListener(FloatSignalListener listener)
    {
        listeners.Remove(listener);
    }
}
