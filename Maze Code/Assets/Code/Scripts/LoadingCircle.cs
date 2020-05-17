using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingCircle : MonoBehaviour
{

    public static bool loading;
    private static bool changed;

    public static GameObject images;
    public GameObject _images;
    // Start is called before the first frame update
    public static void UpdateLoad(bool b){
        loading = b;
        images.SetActive(b);
    }

    private void Start() {
        images = _images;
    }
}
