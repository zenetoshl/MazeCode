using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressCircle : MonoBehaviour
{
    public Image circle;
    public float rotateSpeed = 0.2f;
    private float fill = 0f;

    private void Update()
    {   
        fill =  Mathf.Abs(((rotateSpeed*Time.deltaTime) + fill)%1);
        circle.fillAmount = fill;
    }
}
