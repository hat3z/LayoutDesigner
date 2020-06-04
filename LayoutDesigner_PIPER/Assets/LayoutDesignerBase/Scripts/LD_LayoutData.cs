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

    public LayoutPoint(int _x, int _y)
    {
        x = _x;
        y = _y;
    }

}

[System.Serializable]
public class LayoutWall
{
    public string WallName;
    public int ID;
    public LayoutPoint startPoint;
    public LayoutPoint endPoint;

    public LayoutWall (string _name, LayoutPoint _s, LayoutPoint _e)
    {
        WallName = _name;
        startPoint = _s;
        endPoint = _e;
    }

}

