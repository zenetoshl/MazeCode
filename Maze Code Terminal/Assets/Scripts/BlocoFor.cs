using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocoFor : Blocos
{
    public int Increment;
        public int Begin;
        public string EndOp;
        public List<Blocos> altFlux;

        //public ForBloco(int id, int begin, string end, int increment, List<Blocos> altFlux)
        //{
        //    Begin = begin;
        //    EndOp = end;
        //    Increment = increment;
        //    this.altFlux = altFlux;
        //}

        public override string toCode()
        {
            string BlocoCode = "for(int i =" + Begin +";"+ EndOp + "; i = i +(" + Increment + ")){";
            foreach (Blocos b in altFlux)
            {
                BlocoCode = BlocoCode + b.toCode();
            }
            BlocoCode = BlocoCode + "}";
            return BlocoCode;
        }
}
