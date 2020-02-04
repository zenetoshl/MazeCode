using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BlocoFor : Bloco
{
        public TextMeshProUGUI boolean;
        public TextMeshProUGUI increment;
        public TextMeshProUGUI variable1;
        public TextMeshProUGUI booleanOp;
        public TextMeshProUGUI variable2Dropdown;
        public TextMeshProUGUI variable2Text;
        public TextMeshProUGUI mathOp;
        public TextMeshProUGUI incrementValue;
        public Toggle toggle;
        private string forIncrement;
        private string forBegin;
    

        public override string ToCode()
        {
            string BlocoCode = "for( "+ forBegin +";"+ boolean.text + ";" + forIncrement + ")";
            return BlocoCode;
        }

        public void onWindowOff(){
            string aux = toggle.isOn ? variable2Dropdown.text : variable2Text.text;
            boolean.text =  variable1.text + " " + booleanOp.text + " " + aux;
            increment.text =  mathOp.text + incrementValue.text;
            forIncrement = variable1.text + " = " + variable1.text + mathOp.text + incrementValue.text;
            forBegin = "int " + variable1.text + " = " + "0"; 

        }
}
