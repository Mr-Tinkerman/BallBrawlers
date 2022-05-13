using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NodePath
{
    [SerializeField]
    private List<Vector3> Nodes;

    public NodePath()
    {
        Nodes.Add(Vector3.zero);
    }

    public void AddSegment(Vector3 anchorNode, Vector3 tangentNode)
    {
        Nodes.Add(tangentNode);
        Nodes.Add(anchorNode);
    }

    public float GetApproxLength(int startIndex, int resolution = 32)
    {
        float len = 0;
        float res = 1f / resolution;

        if (startIndex + 2 >= Nodes.Count)
        {
            Debug.LogWarning("startingIndex is out of range!");
            return -1;
        }

        for (int i = 0; i < resolution; ++i)
        {
            len += (QuadraticInterpolation(Nodes[startIndex], Nodes[startIndex + 1], Nodes[startIndex + 2], res * (i + 1))
                  - QuadraticInterpolation(Nodes[startIndex], Nodes[startIndex + 1], Nodes[startIndex + 2], res * i)
                    ).magnitude;
        }

        return len;
    }

    public Vector3 QuadraticInterpolation(Vector3 A, Vector3 B, Vector3 C, float t)
    {
        // A + 2Bt - 2At + C(t^2) - 2B(t^2) + A(t^2)
        return A + (2 * B * t) - (2 * A * t) + (C * (t * t)) - (2 * B * (t * t)) + (A * (t * t));
    }
}