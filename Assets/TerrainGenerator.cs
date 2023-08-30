using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public CinemachineSmoothPath smoothPath;
    public CinemachineDollyCart cart;
    public Vector2 mapSize;
    public Vector3 testV;
    private void GenerateMap()
    {
        SetTrackPath();
    }
    
    [ContextMenu("Set Track Path")]
    void SetTrackPath()
    {
        int waypointCount = 25;
        smoothPath.m_Waypoints = new CinemachineSmoothPath.Waypoint[waypointCount];
        for (int i  =0;i<waypointCount;i++)
        {
            float x = (float)i / (waypointCount - 1);
            Vector2 pointPosition = new Vector2((x-0.75f)*(x-0.75f)*x*16f, x);
            pointPosition.Scale(mapSize);
            pointPosition = (pointPosition + mapSize*0.5f) * 0.5f;
            smoothPath.m_Waypoints[i] = GetWayPoint(pointPosition);
        }

        smoothPath.m_Resolution = 4;

        CinemachineSmoothPath.Waypoint GetWayPoint(Vector2 v)
        {
            CinemachineSmoothPath.Waypoint wp = new CinemachineSmoothPath.Waypoint();
            wp.roll = 0;
            wp.position = new Vector3(v.x,0f,v.y);
            return wp;
        }
    }

    void GenerateItem()
    {
        
    }
}
