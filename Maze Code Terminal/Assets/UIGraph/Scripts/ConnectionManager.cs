﻿using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ConnectionManager : MonoBehaviour
{
    static ConnectionManager _instance;
    public static ConnectionManager instance
    {
        get
        {
            if (!_instance)
            {
                //first try to find one in the scene
                _instance = FindObjectOfType<ConnectionManager>();

                if (!_instance)
                {
                    //if that fails, make a new one
                    GameObject go = new GameObject("_ConnectionManager");
                    _instance = go.AddComponent<ConnectionManager>();

                    if (!_instance)
                    {
                        //if that still fails, we have a big problem;
                        Debug.LogError("Fatal Error: could not create ConnectionManager");
                    }
                }
            }

            return _instance;
        }
    }

    [SerializeField] Connection connectionPrefab;
    [SerializeField] List<Connection> connections = new List<Connection>();

    public static Connection FindConnection(RectTransform t1, RectTransform t2)
    {
        if (!instance) return null;

        foreach (Connection connection in instance.connections)
        {
            if (connection == null) continue;

            if (connection.Match(t1, t2))
            {
                return connection;
            }
        }

        return null;
    }

    public static List<Connection> FindConnections(RectTransform transform)
    {
        List<Connection> found = new List<Connection>();
        if (!instance) return found;

        foreach (Connection connection in instance.connections)
        {
            if (connection == null) continue;

            if (connection.Contains(transform))
            {
                found.Add(connection);
            }
        }

        return found;
    }

    public static List<Connection> FindNextNodes(RectTransform transform, int i)
    {
        List<Connection> found = new List<Connection>();
        if (!instance) return found;

        foreach (Connection connection in instance.connections)
        {
            if (connection == null) continue;
            if (connection.target[i].Equals(transform))
            {
                found.Add(connection);
            }
        }
        return found;
    }

    public static bool IsInChain(RectTransform transform, RectTransform newTransform)
    {
		List<Connection> conns = FindNextNodes(transform, 0);
		foreach(Connection c in conns){
			Debug.Log(transform + ": " + c.target[0] + " == " + newTransform + " ?");
			if(c.target[1].Equals(newTransform) || c.target[0].Equals(newTransform) )
			{
				return true;
			} else
			conns = conns.Concat(FindNextNodes(c.target[1], 0)).ToList();
		}
		return false;
    }

    public static void AddConnection(Connection c)
    {
        if (c == null || !instance) return;

        if (!instance.connections.Contains(c))
        {
            c.transform.SetParent(instance.transform);
            instance.connections.Add(c);
        }
    }

    public static void RemoveConnection(Connection c)
    {
        //don't use the property here. We don't want to create an instance when the scene loads
        if (c != null && _instance != null) _instance.connections.Remove(c);
    }

    public static void SortConnections()
    {
        if (!instance) return;

        instance.connections.Sort((Connection c1, Connection c2) => { return string.Compare(c1.name, c2.name); });
        for (int i = 0; i < instance.connections.Count; i++)
        {
            instance.connections[i].transform.SetSiblingIndex(i);
        }
    }

    public static void CleanConnections()
    {
        if (!instance) return;

        //fist clean any null entries
        instance.connections.RemoveAll((Connection c) => { return c == null; });

        //copy list because OnDestroy messages will modify the original
        List<Connection> copy = new List<Connection>(instance.connections);
        foreach (Connection c in copy)
        {
            if (c && !c.isValid)
            {
                DestroyImmediate(c.gameObject);
            }
        }
    }

    public static Connection CreateConnection(RectTransform t1, RectTransform t2 = null)
    {
        if (!instance) return null;

        Connection conn;

        if (instance.connectionPrefab)
        {
            conn = Instantiate<Connection>(instance.connectionPrefab);
        }
        else
        {
            conn = new GameObject("new connection").AddComponent<Connection>();
        }

        conn.SetTargets(t1, t2);
		AddConnection(conn);
        return conn;
    }

    public static GameObject GetOtherSide(RectTransform t, ConnectionPoint.ConnectionDirection dir)
    {
        if (!instance) return null;

        foreach (Connection c in instance.connections)
        {
            if (dir == ConnectionPoint.ConnectionDirection.West)
            {
                if (c.isTargetOne(t, dir) && c.isValid)
                {
                    NewConnection[] conns = c.target[0].gameObject.transform.GetComponentsInChildren<NewConnection>();

                    foreach (NewConnection conn in conns)
                    {
                        if (conn.connectionDir == c.points[0].direction)
                        {

                            return conn.gameObject;
                        }
                    }
                }
            }
            else if (c.isTargetZero(t, dir) && c.isValid)
            {
                EntryPoint conn;
                foreach (Transform child in c.target[1].gameObject.transform)
                {

                    conn = child.gameObject.GetComponent<EntryPoint>();
                    if (conn.connectionDir == c.points[1].direction)
                    {
                        return child.gameObject;
                    }
                }
            }
        }
        return null;
    }

    public static bool DeleteThisConnection(RectTransform t, ConnectionPoint.ConnectionDirection dir)
    {
        if (!instance) return false;

        foreach (Connection c in instance.connections)
        {
            if (dir == ConnectionPoint.ConnectionDirection.West)
            {
                if (c.isTargetOne(t, dir) && c.isValid)
                {
                    Destroy(c.target[0].gameObject.GetComponent<GraphNode>());
                    Destroy(c.target[1].gameObject.GetComponent<GraphNode>());
                    DestroyImmediate(c.gameObject);
                    return true;
                }
            }
            else if (c.isTargetZero(t, dir) && c.isValid)
            {
                Destroy(c.target[0].gameObject.GetComponent<GraphNode>());
                Destroy(c.target[1].gameObject.GetComponent<GraphNode>());
                DestroyImmediate(c.gameObject);
                return true;
            }
        }
        return false;
    }
}