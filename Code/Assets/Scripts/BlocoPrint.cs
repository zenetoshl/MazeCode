using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocoPrint : Bloco
{
        public string Variavel;
        public override string ToCode()
        {
            return "Console.WriteLine(" + Variavel + ");";
        }
}
