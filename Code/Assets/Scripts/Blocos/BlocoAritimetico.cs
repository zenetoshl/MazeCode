using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocoAritimetico : Bloco
{
    
        public string MathEq;
        public override string ToCode()
        {
            return MathEq;
        }
}
