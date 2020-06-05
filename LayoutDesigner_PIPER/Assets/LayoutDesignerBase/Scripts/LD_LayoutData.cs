using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LD_LayoutData
{
    public string LayoutName;
    public List<RoomData> Rooms;

    public void AddRoomData(RoomData _roomData)
    {
        Rooms.Add(_roomData);
    }

}

[System.Serializable]
public class RoomData
{
    public string RoomName;
    public string ID;
    public List<LayoutWall> Walls = new List<LayoutWall>();
    public List<LayoutPoint> Points = new List<LayoutPoint>();

    public RoomData(string _ID)
    {
        ID = _ID;
    }
    public void AddPoints(List<LayoutPoint> layoutPoints)
    {
        for (int i = 0; i < layoutPoints.Count; i++)
        {
            Debug.Log(layoutPoints[i]);
            Points.Add(layoutPoints[i]);
        }
    }

}

[System.Serializable]
public class LayoutPoint
{
    public int ID;
    public float x;
    public float y;

    public LayoutPoint(int _ID, float _x, float _y)
    {
        ID = _ID;
        x = _x;
        y = _y;
    }

}

[System.Serializable]
public class LayoutWall
{
    public string WallName;
    public string ID;
    public LayoutPoint startPoint;
    public LayoutPoint endPoint;


    public void AssignStartPoint(string _n ,LayoutPoint _s, string _ID)
    {
        WallName = _n;
        startPoint = _s;
        ID = _ID;
    }

    public void AssignEndPoint(LayoutPoint _e)
    {
        endPoint = _e;
    }

}

