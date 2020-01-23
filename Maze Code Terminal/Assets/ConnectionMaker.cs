using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionMaker : MonoBehaviour
{
    public RectTransform[] connectionPos;
    public ConnectionPoint.ConnectionDirection[] connectionDirections;
    private Connection conn;
    public void AddConnection (RectTransform t, ConnectionPoint.ConnectionDirection cd){
        Debug.Log("0 antes: " + connectionPos[0]);
        if (!connectionPos[0]) {connectionPos[0] = t; connectionDirections[0] = cd;}
        else if (!connectionPos[1]){ connectionPos[1] = t;  connectionDirections[1] = cd;}
        Debug.Log("0 depois: {0}" + connectionPos[0]);
        Debug.Log("1 depois: {0}" + connectionPos[1]);
    }
    private void Awake() {
        connectionPos = new RectTransform[2];
        connectionDirections = new ConnectionPoint.ConnectionDirection[2];
    }

    // Update is called once per frame
    void Update()
    {
        if( !(!connectionPos[0] || !connectionPos[1])){
            conn = ConnectionManager.CreateConnection(connectionPos[0], connectionPos[1]);
            conn.points[0].direction = connectionDirections[0];
            conn.points[1].direction = connectionDirections[1];
            Destroy(this.gameObject);
        }
    }
}
