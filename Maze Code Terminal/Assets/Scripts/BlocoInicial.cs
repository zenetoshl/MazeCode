using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocoInicial : Blocos
{
        public string Entries = "";
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

        void Start(){
            Debug.Log(this.toCode());
        }
}
