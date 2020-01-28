using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocoIf : Bloco
{
    // Start is called before the first frame update
        public string LogicOp;

        public override string ToCode()
        {
            string BlocosCode = "if("+ LogicOp +")";
            return BlocosCode;
        }
}
