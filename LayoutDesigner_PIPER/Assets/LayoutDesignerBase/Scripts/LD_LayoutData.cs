using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LD_LayoutData
{

    public List<RoomData> Rooms;

}

[System.Serializable]
public class RoomData
{
    public string roomName;
    public int ID;
    public List<LayoutWall> Walls;
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
    public string wallName;
    public int ID;
    public LayoutPoint startPoint;
    public LayoutPoint endPoint;
}

