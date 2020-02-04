using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocoInicial : Bloco
{
        public string init = "";
        public string code = "";

        public override string ToCode()
        {
            
            code = "using System;using System.Collections.Generic;using UnityEngine;using System.Text;namespace Soma { class Test {void soma(){";
            
            init = @"
                int a = 10;
                int b = 20;
                int c = 30;";
            code = code + init;
            return code;
        }
}
