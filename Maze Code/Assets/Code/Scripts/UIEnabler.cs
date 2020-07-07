using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEnabler : MonoBehaviour
{
    // Start is called before the first frame update
    public void UpdateUI(bool b){
        UIManager.ChangeWindowStatus(b);
    }
}
