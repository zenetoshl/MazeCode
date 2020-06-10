using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class _Signal : ScriptableObject
{
    public List<_SignalListener> listeners = new List<_SignalListener> ();

    public void Raise()
    {
        for(int i = listeners.Count - 1; i >=0; i --)
        {
            listeners[i].OnSignalRaised();
        }
    }

    public void RegisterListener(_SignalListener listener)
    {
        listeners.Add(listener);
    }

    public void DeRegisterListener(_SignalListener listener)
    {
        listeners.Remove(listener);
    }
}