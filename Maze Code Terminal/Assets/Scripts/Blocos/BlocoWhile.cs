using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocoWhile : Bloco
{
    public string LogicOp;
        public override string ToCode()
        {
            string BlocoCode = "while(" + LogicOp + ")";
            return BlocoCode;
        }
}
