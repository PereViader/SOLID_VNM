﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public static class XNode_Extensions
{
    public static T GetOutputConnection<T>(this Node node, string name) where T : Node
    {
        NodePort nodePort = node.GetPort(name);
        if (nodePort == null)
        {
            Debug.LogWarning("Requested NodePort connection is null");
            return null;
        }

        if (nodePort.ConnectionCount > 1)
        {
            Debug.LogWarning("Requested NodePort has more than 1 connection");
            return null;
        }

        if (nodePort.ConnectionCount == 0)
        {
            return null;
        }
        else
        {
            return nodePort.Connection.node as T;
        }
    }

    public static T[] GetOutputConnections<T>(this Node node, string name) where T : Node
    {
        NodePort nodePort = node.GetPort(name);
        if (nodePort == null)
        {
            Debug.LogWarning("Requested NodePort connection is null");
            return null;
        }

        T[] nodes = new T[nodePort.ConnectionCount];
        for (int i = 0; i < nodePort.ConnectionCount; i++)
        {
            nodes[i] = nodePort.GetConnection(i).node as T;
        }
        return nodes;
    }
}
