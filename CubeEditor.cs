using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof (Waypoint))]
public class CubeEditor : MonoBehaviour
{
    Vector3 gridPos;
    Waypoint waypoint;

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    void Update()
    {
        SnapGrid();
        ShowLabel();
    }

    private void SnapGrid()
    {
        int gridSize = waypoint.GetGridSize();
        transform.position = new Vector3(
            waypoint.GetGridPos().x,
            0,
            waypoint.GetGridPos().y);
    }

    private void ShowLabel()
    {
        int gridSize = waypoint.GetGridSize();
        string labelText = waypoint.GetGridPos().x/ gridSize + " , " + waypoint.GetGridPos().y/ gridSize;
        gameObject.name = labelText;
    }

}
