using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DestroyButtonManager : MonoBehaviour {
    public static RectTransform activeButton;

    public static void UpdateActive (RectTransform newActiveButton) {
        if (activeButton != null) {
            activeButton.gameObject.SetActive (false);
        }
        if (newActiveButton != null) {
            activeButton = newActiveButton;
            activeButton.gameObject.SetActive (true);
        }
    }

    private void Update() {
        /* if (Input.GetButtonDown ("Fire1") && activeButton != null && !EventSystem.current.IsPointerOverGameObject()) {
            UpdateActive(null);
        }*/
    }

}