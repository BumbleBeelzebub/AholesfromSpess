using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placeableObject : MonoBehaviour
{
    public bool placed {  get; private set; }
    public Vector3Int size {  get; private set; }
    private Vector3[] vertices;

    private void getColliderVetexPosLocal()
    {
        BoxCollider b = gameObject.GetComponent<BoxCollider>();
        vertices = new Vector3[4];

        vertices[0] = b.center + new Vector3(-b.size.x, -b.size.y, -b.size.z) * 0.5f ;
        vertices[1] = b.center + new Vector3(b.size.x, -b.size.y, -b.size.z) * 0.5f;
        vertices[2] = b.center + new Vector3(b.size.x, -b.size.y, b.size.z) * 0.5f;
        vertices[3] = b.center + new Vector3(-b.size.x, -b.size.y, b.size.z) * 0.5f;
    }

    private void CalculateSizeInCells ()
    {
        Vector3Int[] verts = new Vector3Int[vertices.Length];

        for (int i = 0; i < verts.Length; i++)
        {
            Vector3 worldpos = transform.TransformPoint(vertices[i]);
            verts[i] = buildingSystem.current.GridLayout.WorldToCell(worldpos);
        }

        size = new Vector3Int(Math.Abs ((verts[0] - verts[1]).x), Math.Abs((verts[0] - verts[3]).y), 1);
    }


public Vector3 getStartPosition()
    {
        return transform.TransformPoint(vertices[0]);
    }

    private void Start()
    {
        getColliderVetexPosLocal();
        CalculateSizeInCells();

    }


    public virtual void Place ()
    {
        objectDrag drag = gameObject.GetComponent<objectDrag>();
        Destroy(drag);
        placed = true;
    }
}
