using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocoVariavel : Blocos
{
    // Start is called before the first frame update
     /*public ArithmeticBloco(int id, string mathEq)
        {
            MathEq = mathEq;
        }
        */
        public string Variavel;
        public override string toCode()
        {
            return Variavel;
        }
}
