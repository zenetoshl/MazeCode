using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    private bool scaling = false;
    private bool reseting = false;
    private Vector3 normalScale;
    private Vector3 maxScale;
    public float scaleRatio = 0.005f;

    public void SetScaling(bool b){
        if (b){
            reseting = false;
        }
        scaling = b;
    }

    public void ResetScaling(){
        scaling = false;
        reseting = true;
    }

    public void ToNormalScale(){
        this.gameObject.transform.localScale = normalScale;
    }

    private void Start() {
        normalScale = this.gameObject.transform.localScale;
        maxScale = normalScale + new Vector3(0.1f, 0.1f, 0);
    }
    public void Scale(){
        if(scaling && this.gameObject.transform.localScale.x < maxScale.x){
                this.gameObject.transform.localScale += new Vector3(scaleRatio, scaleRatio, 0);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (reseting){
            if (normalScale.x >= this.gameObject.transform.localScale.x){
                this.gameObject.transform.localScale = normalScale;
                reseting = false;
            } else {
                 this.gameObject.transform.localScale -= new Vector3(scaleRatio * 2, scaleRatio * 2, 0);
            }
        }
    }
}
