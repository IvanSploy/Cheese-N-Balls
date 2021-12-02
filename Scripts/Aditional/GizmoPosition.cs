using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoPosition : MonoBehaviour
{
    //Editor
    [Range(0,10)]
    public float radious;
    public Color color;

    private void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawCube(transform.position, Vector3.one * radious);
    }
}
