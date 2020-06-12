using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
//este script deve estar no seu Player e deve ter o nome "SalvarPosic"
public class SavePosition : MonoBehaviour
{

    string nomeCenaAtual;

    void Awake()
    {
        nomeCenaAtual = SceneManager.GetActiveScene().name;
    }

    void Start()
    {
        if (PlayerPrefs.HasKey(nomeCenaAtual + "X") && PlayerPrefs.HasKey(nomeCenaAtual + "Y") && PlayerPrefs.HasKey(nomeCenaAtual + "Z"))
        {
            transform.position = new Vector3(PlayerPrefs.GetFloat(nomeCenaAtual + "X"), PlayerPrefs.GetFloat(nomeCenaAtual + "Y"), PlayerPrefs.GetFloat(nomeCenaAtual + "Z"));
        }
    }
    
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            DeletarLocalizacao();
        }
    }
    public void SalvarLocalizacao()
    {
        PlayerPrefs.SetFloat(nomeCenaAtual + "X", transform.position.x);
        PlayerPrefs.SetFloat(nomeCenaAtual + "Y", transform.position.y);
        PlayerPrefs.SetFloat(nomeCenaAtual + "Z", transform.position.z);
    }
    public void DeletarLocalizacao()
    {
        PlayerPrefs.DeleteKey(nomeCenaAtual + "X");
        PlayerPrefs.DeleteKey(nomeCenaAtual + "Y");
        PlayerPrefs.DeleteKey(nomeCenaAtual + "Z");
    }
}