using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class Var_Vet_Mat : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject dropdown;
    private TMP_Dropdown TMPdropdown;
    private VariableManager.StructureType state;
    public VariableManager.Type type;

    public ToggleManager vet;
    public ToggleManager mat;

    private string lastName;

    private void Start()
    {
        lastName = "";
        TMPdropdown = this.GetComponent<TMP_Dropdown>();
        UpdateText();
        UpdateState();
    }

    public void UpdateState()
    {
        state = VariableManager.ReturnStructureType(GetName());
        type = VariableManager.GetTypeOf(GetName());
        Debug.Log(state);
        if (state == null)
        {
            Debug.Log("state is set as null, variable don't exist");
            state = VariableManager.StructureType.Variable;
        }
        UpdateUi();
    }

    public void UpdateUi()
    {
        switch (state)
        {
            case VariableManager.StructureType.Array:
                mat.gameObject.SetActive(false);
                vet.gameObject.SetActive(true);
                break;
            case VariableManager.StructureType.Matriz:
                mat.gameObject.SetActive(true);
                vet.gameObject.SetActive(true);
                break;
            case VariableManager.StructureType.Variable:
                mat.gameObject.SetActive(false);
                vet.gameObject.SetActive(false);
                break;
        }
    }

    public string GetText()
    {
        string text = this.transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>().text;
        switch (state)
        {
            case VariableManager.StructureType.Array:
                return text + "[" + vet.GetActiveText() + "]";
            case VariableManager.StructureType.Matriz:
                return text + "[" + vet.GetActiveText() + "]" + "[" + mat.GetActiveText() + "]";
            case VariableManager.StructureType.Variable:
                return text;
        }
        return null;
    }

    public string GetName()
    {
        return this.transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>().text;
    }

    public void SaveConfig()
    {
        lastName = GetName();
        vet.SaveConfig();
        mat.SaveConfig();
    }

    private int FindByText(string name)
    {
        for (int i = 0; i <= TMPdropdown.options.Capacity - 1; i++)
        {
            if (TMPdropdown.options[i].text == name)
            {
                return i;
            }
        }
        return 0;
    }

    private void Update()
    {
        if (VariableManager.changed)
        {
            UpdateText();
        }
    }

    private void UpdateText(){
            int i = TMPdropdown.value;
            TMPdropdown.options.Clear();
            foreach (string option in VariableManager.ListNames())
            {
                TMPdropdown.options.Add(new TMP_Dropdown.OptionData(option));
            }
            if(VariableManager.ExistSameName(lastName)){
                i = FindByText(lastName);
                TMPdropdown.value = i;
            }
            TMPdropdown.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = TMPdropdown.options[i].text;
            UpdateState();
            SaveConfig();
    }


    public void ResetConfig()
    {
        TMPdropdown.value = FindByText(lastName);
        UpdateState();
        vet.ResetConfig();
        mat.ResetConfig();
    }

    public bool Compile(List<string> scope){
        switch (state)
        {
            case VariableManager.StructureType.Array:
                foreach(string str in scope){
                    if (str == GetName()){
                        return vet.Compile(scope);
                    }
                }
                break;
            case VariableManager.StructureType.Matriz:
                foreach(string str in scope){
                    if (str == GetName()){
                        return vet.Compile(scope) && mat.Compile(scope);
                    }
                }
                break;
            case VariableManager.StructureType.Variable:
                foreach(string str in scope){
                    if (str == GetName()){
                        return true;
                    }
                }
                break;
        }
        return false;
    }


}
