using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocoWhile : Blocos
{
    public string LogicOp { get; set; }
        public List<Blocos> altFlux = new List<Blocos>();
        /*public WhileBloco(int id, string logicOp, List<Blocos> altFlux)
        {
            LogicOp = logicOp;
            this.altFlux = altFlux;
        }
        */

        public override string toCode()
        {
            string BlocoCode = "while(" + LogicOp + "){";
            foreach (Blocos b in altFlux)
            {
                BlocoCode += b.toCode();
            }
            BlocoCode = BlocoCode + "}";
            return BlocoCode;
        }
}
