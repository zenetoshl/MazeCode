using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Lean.Gui;

public class Validator : MonoBehaviour
{
    public Text invalid;
    public TMP_InputField name;
    public Text registered;
    public LeanButton okButton;
    
    private string[] systemVars  = {"abstract",	"bool",	"continue",	"decimal",	"default",
"event",	"explicit",	"extern",	"char",	"checked",
"class",	"const",	"break",	"as",	"base",
"delegate",	"is",	"lock"	,"long",	"num",
"byte",	"case",	"catch",	"false",	"finally",
"fixed",	"float",	"for",	"as",	"foreach",
"goto",	"if",	"implicit",	"in",	"int",
"interface",	"internal",	"do",	"double",	"else"
,"namespace",	"new",	"null",	"object",	"operator",
"out",	"override",	"params",	"private",	"protected",
"public",	"readonly",	"sealed",	"short",	"sizeof",
"ref",	"return",	"sbyte",	"stackalloc",	"static",
"string",	"struct",	"void",	"volatile",	"while",
"true",	"try",	"switch",	"this",	"throw",
"unchecked",	"unsafe",	"ushort",	"using",	"using", "static",
"virtual",	"typeof",	"uint",	"ulong",	"out", 
"add",	"alias",	"async",	"await",	"dynamic",
"from",	"get",	"orderby",	"ascending",	"decending",
"group",	"into",	"join",	"let",	"nameof",
"global",	"partial",	"set",	"remove",	"select",
"value",	"var",	"when",	"Where",	"yield"};

    public void validade(){
        if (CheckChars()){
            registered.enabled = false;
            invalid.enabled = true;
            okButton.interactable = false;
        } else if(ExistsIn(name.text, systemVars)){
            registered.enabled = false;
            invalid.enabled = true;
            okButton.interactable = false;
        } else if (ExistsIn(name.text, VariableManager.ListNames())){
            registered.enabled = true;
            invalid.enabled = false;
            okButton.interactable = false;
        } else {
            registered.enabled = false;
            invalid.enabled = false;
            okButton.interactable = true;
        }
    }

    private bool CheckChar(char c){
        int number = c;
        Debug.Log((number >= 65 && number <= 90) || (number >= 97 && number <= 122));
        return (number >= 65 && number <= 90) || (number >= 97 && number <= 122);
    }

    public bool CheckChars(){
        foreach (char c in name.text){
            if (!CheckChar(c)){
                return true;
            }
        }
        return false;
    }

    private bool ExistsIn(string name, List<string> list){
        name = name.ToLower();
        foreach (string item in list)
        {
            if(name == item.ToLower()){
                return true;
            }
        }
        return false;
    }

    private bool ExistsIn(string name, string[] list){
        name = name.ToLower();
        foreach (string item in list)
        {
            if(name == item.ToLower()){
                return true;
            }
        }
        return false;
    }
}
