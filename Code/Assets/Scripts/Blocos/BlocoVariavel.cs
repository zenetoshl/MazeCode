using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocoVariavel : Bloco
{
    
        public string Variavel;
        public override string ToCode()
        {
            return Variavel;
        }
}
