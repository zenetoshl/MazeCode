using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToCode : MonoBehaviour
{
    // Start is called before the first frame update
    public string Code()
    {
        Bloco block = this.gameObject.GetComponent<Bloco>();
        return block.ToCode();
    }

    public bool Compile(){
        Bloco block = this.gameObject.GetComponent<Bloco>();
        return block.Compile();
    }


    /*
    Bloco block = this.gameObject.GetComponent<BlocoFor>();
        if (block == null)
        {
            block = this.gameObject.GetComponent<BlocoWhile>();
            if (block == null)
            {
                block = this.gameObject.GetComponent<BlocoIf>();
                if (block == null)
                {
                    block = this.gameObject.GetComponent<BlocoAritimetico>();
                    if (block == null)
                    {
                        block = this.gameObject.GetComponent<BlocoVariavel>();
                        if (block == null)
                        {
                            block = this.gameObject.GetComponent<BlocoInicial>();
                            if (block == null)
                            {
                                block = this.gameObject.GetComponent<BlocoPrint>();
                            }
                        }
                    }
                }
            }
        }
    */
}
