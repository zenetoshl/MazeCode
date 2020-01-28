using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionMaker : MonoBehaviour
{
    public static bool isConnectionMode = false;
    public static RectTransform[] connectionPos = new RectTransform[2];
    public static ConnectionPoint.ConnectionDirection[] connectionDirections = new ConnectionPoint.ConnectionDirection[2];
    private Connection conn;

    public void AddConnection(RectTransform t, ConnectionPoint.ConnectionDirection cd)
    {
        if (connectionPos[0] == t)
        {
            return;
        }
        if (!connectionPos[0]) { isConnectionMode = true; connectionPos[0] = t; connectionDirections[0] = cd; }
        else if (!connectionPos[1]) { connectionPos[1] = t; connectionDirections[1] = cd; }
    }

    // Update is called once per frame
    void Update()
    {
        if (!(!connectionPos[0] || !connectionPos[1]))
        {
            conn = ConnectionManager.CreateConnection(connectionPos[0], connectionPos[1]);
            conn.points[0].direction = connectionDirections[0];
            conn.points[1].direction = connectionDirections[1];
            Destroy(this.gameObject);
        }
    }

    private void OnDestroy()
    {
        connectionPos[0] = null;
        connectionPos[1] = null;
        isConnectionMode = false;
    }
}
