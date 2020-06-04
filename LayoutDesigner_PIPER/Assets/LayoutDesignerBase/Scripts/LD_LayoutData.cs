using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LD_LayoutData
{

    public class RoomData
    {

    }



    public class LayoutPoint
    {
        public int x;
        public int y;

        public LayoutPoint(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

    }

    public class LayoutWall
    {
        public LayoutPoint startPoint;
        public LayoutPoint endPoint;
    }   

}
