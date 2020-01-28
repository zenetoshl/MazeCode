using UnityEngine;
using UnityEngine.UI;


public class BlocoInventario : MonoBehaviour
{
    // Start is called before the first frame update
    public Bloco bloco;
    public GameObject prefab;

    public void setObject(){
        CriarBloco.prefab = prefab;
        CriarBloco.clicked = true;
    }
}
