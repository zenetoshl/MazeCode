﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class BoolValue : ScriptableObject, ISerializationCallbackReceiver
{
    public bool initialValue;

    public bool RuntimeValue;

    public void OnAfterDeserialize() { }

    public void OnBeforeSerialize() { }
}