using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ErrorLogManager : MonoBehaviour {

    public TextMeshProUGUI tmproPrefab;
    public Transform content;
    public Button logButton;
    private int i = 1;

    public static ErrorLogManager instance;

    private void Awake() {
        instance = this;
    }


    public void CreateError (string error) {
        TextMeshProUGUI myNewError = Instantiate (tmproPrefab, new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity, content);
        myNewError.text = i + " - " + error;
        i++;
        logButton.interactable = true;
    }

    public void ClearErrors () {
        i = 1;
        foreach (Transform child in content) {
            Destroy (child.gameObject);
        }
        logButton.interactable = false;
    }

}