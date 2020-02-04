using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLines : MonoBehaviour {

    [SerializeField]
    private GameObject lineGeneratorPrefab;
    [SerializeField]
    private GameObject linePointPrefab;

    public void Update() {
        if(Input.GetMouseButtonDown(0)){
            Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPos.z = 0;
            CreatePointMarker(newPos);
        }
        if(Input.GetMouseButtonDown(1)){
            ClearAllPoints();
        }
        if(Input.GetKeyDown("e")){
            GenerateNewLine();
        }
    }

    private void CreatePointMarker(Vector3 pointPosition){
        Instantiate(lineGeneratorPrefab, pointPosition, Quaternion.identity);
    }

    private void ClearAllPoints(){
        GameObject[] allPoints = GameObject.FindGameObjectsWithTag("PointMarker");
        foreach(GameObject p in allPoints){
            Destroy(p);
        }
    }

    private void GenerateNewLine(){
        GameObject[] allPoints = GameObject.FindGameObjectsWithTag("PointMaker");
        Vector3 [] allPointsPositions = new Vector3[allPoints.Length];
        if(allPoints.Length >= 2){
            for(int i=0; i<allPoints.Length; i++){
                allPointsPositions[i] = allPoints[i].transform.position;
            }
            SpawnLineGenerator(allPointsPositions);
        }
        else{
            Debug.Log("Need 2 or more points to draw a line");
        }
    }

    private void SpawnLineGenerator(Vector3[] linePoints){
        GameObject newLineGen = Instantiate(lineGeneratorPrefab);
        LineRenderer lRend = newLineGen.GetComponent<LineRenderer>();
        lRend.positionCount = linePoints.Length;
        lRend.SetPositions(linePoints);
        Destroy(newLineGen, 5);
    }
}