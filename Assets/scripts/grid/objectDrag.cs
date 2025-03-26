using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectDrag : MonoBehaviour
{
    private Vector3 offset;

    private void OnMouseDown()
    {
        offset = transform.position - buildingSystem.getMousePosition();
    }

    private void OnMouseDrag()
    {
        Vector3 pos = buildingSystem.getMousePosition() + offset;
        transform.position = buildingSystem.current.snapCooordinateToGrid(pos);
    }
}
