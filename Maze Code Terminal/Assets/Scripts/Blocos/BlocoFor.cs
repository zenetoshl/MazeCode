using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocoFor : Bloco
{
    public int Increment;
        public int Begin;
        public string EndOp;

        public override string ToCode()
        {
            string BlocoCode = "for(int i =" + Begin +";"+ EndOp + "; i = i +(" + Increment + "))";
            return BlocoCode;
        }
}
