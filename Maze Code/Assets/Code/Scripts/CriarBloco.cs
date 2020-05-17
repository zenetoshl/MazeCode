using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CriarBloco : MonoBehaviour {
    Vector3 ray;
    public static bool clicked;
    public static GameObject prefab;
    public static float ScreenPoint = 0;

    // Use this for initialization
    void Start () {
        clicked = false;
    }

    // Update is called once per frame
    void Update () {
        Vector3 pos = Input.mousePosition;
        if (Input.GetButtonDown ("Fire1") && clicked && !EventSystem.current.IsPointerOverGameObject()) {
            clicked = false;
            ray = Camera.main.ScreenToWorldPoint (pos);
            ray.z = 0.0f;
            GameObject.Instantiate (prefab, ray, Quaternion.identity);

        }

    }

}