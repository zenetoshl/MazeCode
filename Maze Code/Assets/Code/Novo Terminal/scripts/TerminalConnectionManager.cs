using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalConnectionManager : MonoBehaviour {
    public static RectTransform[] connectionPos = new RectTransform[2];
    public static ConnectionPoint.ConnectionDirection[] connectionDirections = new ConnectionPoint.ConnectionDirection[2];
    private Connection conn;

    public void AddConnection (RectTransform t, ConnectionPoint.ConnectionDirection cd) {
        if (connectionPos[0] == t) {
            return;
        }
        if (!connectionPos[0]) {
            connectionPos[0] = t;
            connectionDirections[0] = cd;
        } else if (!connectionPos[1]) {
            connectionPos[1] = t;
            connectionDirections[1] = cd;
            MakeConnection();
        }
    }

    // Update is called once per frame
    void MakeConnection () {
        if (connectionPos[0] != null && connectionPos[1] != null) {
            conn = ConnectionManager.CreateConnection (connectionPos[0], connectionPos[1]);
            conn.points[0].direction = connectionDirections[0];
            conn.points[1].direction = connectionDirections[1];
            //passar a referencia de um para o outro
            Destroy (this.gameObject);
        }
    }

    private void OnDestroy () {
        connectionPos[0] = null;
        connectionPos[1] = null;
    }
}