using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocoInicial : Bloco {
    private string init = "";
    private string code = "";
    public string name;

    public override string ToCode () {
        init = "int _i = 0;string _output = \"\";List<int> _inputs = new List<int>() {};";
        code = "using System;using System.Collections.Generic;using UnityEngine;using System.Text;namespace " + name + " { class " + "MazeCode" + " {" + init + "void " + name + "(){";
        return code;
    }

    public override void UpdateUI (bool isOk) {
        Bloco.changed = true;
    }

    public override bool Compile () {
        return MarkError(true);
    }

    public override void ToUI(){}
}