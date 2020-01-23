using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Blocos : MonoBehaviour
{
    public abstract string toCode();
}

public class InitialBloco : Blocos
    {

        public InitialBloco(string entries)
        {
            Entries = entries;
        }
        public string Entries { get; set; }
        public List<Blocos> mainFlux = new List<Blocos>();
        private string code = "";

        public override string toCode()
        {
            code = @"
            using System;using System.Collections.Generic;using UnityEngine;using System.Text;namespace Soma { class Test {void soma(){";
            code += Entries;
            foreach (Blocos b in mainFlux)
            {
                code = code + b.toCode();
            }
            code = code + "}}}";
            return code;
        }
    }

    public class IfBloco : Blocos
    {

        public string LogicOp { get; set; }
        public List<Blocos> trueFlux = new List<Blocos>();
        public List<Blocos> falseFlux = new List<Blocos>();

        public IfBloco(int id, string logicOp, List<Blocos> trueFlux, List<Blocos> falseFlux)
        {
            LogicOp = logicOp;
            this.trueFlux = trueFlux;
            this.falseFlux = falseFlux;
        }

        public override string toCode()
        {
            string BlocoCode = "if("+ LogicOp +"){";
            foreach (Blocos b in trueFlux)
            {
                BlocoCode = BlocoCode + b.toCode();
            }
            if (falseFlux.Count != 0)
            {
                BlocoCode = BlocoCode + "}else {";
                foreach (Blocos b in falseFlux)
                {
                    BlocoCode = BlocoCode + b.toCode();
                }
            }
            BlocoCode = BlocoCode + "}";
            return BlocoCode;
        }
    }

    public class ForBloco : Blocos
    {
        public int Increment;
        public int Begin;
        public string EndOp;
        List<Blocos> altFlux;

        public ForBloco(int id, int begin, string end, int increment, List<Blocos> altFlux)
        {
            Begin = begin;
            EndOp = end;
            Increment = increment;
            this.altFlux = altFlux;
        }

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

    public class WhileBloco : Blocos
    {
        public string LogicOp { get; set; }
        public List<Blocos> altFlux = new List<Blocos>();
        public WhileBloco(int id, string logicOp, List<Blocos> altFlux)
        {
            LogicOp = logicOp;
            this.altFlux = altFlux;
        }

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

    public class ArithmeticBloco : Blocos
    {
        public ArithmeticBloco(int id, string mathEq)
        {
            MathEq = mathEq;
        }
        public string MathEq { get; set; }
        public override string toCode()
        {
            return MathEq;
        }
    }
