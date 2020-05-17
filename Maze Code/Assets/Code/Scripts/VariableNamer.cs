using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VariableNamer : MonoBehaviour
{

    public TMP_InputField name;
    public VariableManager.StructureType type;
    // Start is called before the first frame update
    void Start()
    {
        name.text = VariableManager.NextName();
        VariableManager.Create( name.text, VariableManager.Type.Int, type);
    }
}
