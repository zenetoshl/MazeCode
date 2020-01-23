using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocoIF : Blocos
{
    // Start is called before the first frame update
        public string LogicOp { get; set; }
        public List<Blocos> trueFlux = new List<Blocos>();
        public List<Blocos> falseFlux = new List<Blocos>();

        //public IfBlocos(string logicOp, List<Blocos> trueFlux, List<Blocos> falseFlux)
        //{
        //    LogicOp = logicOp;
        //    this.trueFlux = trueFlux;
        //    this.falseFlux = falseFlux;
        //}

        public override string toCode()
        {
            string BlocosCode = "if("+ LogicOp +"){";
            foreach (Blocos b in trueFlux)
            {
                BlocosCode = BlocosCode + b.toCode();
            }
            if (falseFlux.Count != 0)
            {
                BlocosCode = BlocosCode + "}else {";
                foreach (Blocos b in falseFlux)
                {
                    BlocosCode = BlocosCode + b.toCode();
                }
            }
            BlocosCode = BlocosCode + "}";
            return BlocosCode;
        }
}
