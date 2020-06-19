using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClearText : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    public void ClearThisText(){
        text.text = "";
    }
}
