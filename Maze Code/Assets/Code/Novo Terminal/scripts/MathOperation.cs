using System.Collections;
using System.Collections.Generic;

public class MathOperation
{
    public MathOperation op1;
    public MathOperation op2;
    public string var1; //verificar se é um numero ou um nome de variavel, tratar diferente as duas possibilidades, não é possivel ter dois numeros dentro do if
    public string var2; //verificar se é um numero ou um nome de variavel, tratar diferente as duas possibilidades, não é possivel ter dois numeros dentro do if
    public string op;
    private bool isOp;

    public MathOperation(string var){

    }
    public MathOperation(string var1, string var2, string op){

    }
    public double CalcDouble(){ //double tem um . separando as casas decimais, mesmo quando é 0
        return 0.0;
    }

    public int CalcInt(){
        return 0;
    }

    public string CalcString(){ //as strings tem \" \" fechando-as
        return "A";
    }

    public bool CalcBool(){
        return true;
    }
}
