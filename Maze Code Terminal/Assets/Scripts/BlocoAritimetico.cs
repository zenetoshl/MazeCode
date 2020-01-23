using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocoAritimetico : Blocos
{
    // Start is called before the first frame update
     /*public ArithmeticBloco(int id, string mathEq)
        {
            MathEq = mathEq;
        }
        */
        public string MathEq;
        public override string toCode()
        {
            return MathEq;
        }
}
