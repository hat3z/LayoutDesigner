using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LD_LayoutData
{
    public string LayoutName;
    public List<RoomData> Rooms;

}

[System.Serializable]
public class RoomData
{
    public string RoomName;
    public int ID;
    public List<LayoutWall> Walls;
    public List<LayoutPoint> Points;
}

[System.Serializable]
public class LayoutPoint
{
    public int ID;
    public int x;
    public int y;

    public LayoutPoint(int _ID, int _x, int _y)
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

