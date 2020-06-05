using UnityEngine;

/// <summary>
/// author@htz
/// </summary>


public class LD_Controller : MonoBehaviour
{
    // COMMONS
    public static LD_Controller Instance;

    GameObject activePoint;
    GameObject newRoom;
    float distance = 10f;
    public bool useSnap;
    [Header("Wrappers")]
    public Transform RoomsWrapper;
    public Transform PointsWrapper;
    public Transform tempUIWrapper;

    [Header("Prefabs")]
    public GameObject RoomPrefab;
    public GameObject StaticPointPrefab;

    [Space(10)]
    public LD_LayoutData MainData;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;

    }

    // Start is called before the first frame update
    void Start()
    {
        DrawLayout();
    }

    // Update is called once per frame
    void Update()
    {
        if(activePoint != null)
        {
            CreateStaticPointHelperToCursor(activePoint);
        }
    }

    #region ----- Loading Layout -----
    void DrawLayout()
    {
        for (int i = 0; i < MainData.Rooms.Count; i++)
        {
            LoadRoomData(MainData.Rooms[i]);
        }
    }

    void LoadRoomData(RoomData _roomData)
    {
        GameObject roomObject = Instantiate(RoomPrefab);
        roomObject.transform.SetParent(RoomsWrapper, true);
        roomObject.transform.localScale = new Vector3(1, 1, 1);
        roomObject.GetComponent<LD_Room>().CreatePoints(_roomData.Points);
        AssignWalls();
    }

    /// <summary>
    /// Assigning Wall startPoint and endPoint with the given name.
    /// </summary>
    void AssignWalls()
    {
        for (int i = 0; i < MainData.Rooms.Count; i++)
        {
            for (int a = 0; a < MainData.Rooms[i].Points.Count; a++)
            {
                LayoutWall _layoutWall = new LayoutWall();

                _layoutWall.AssignStartPoint("Wall" + (a + 1),MainData.Rooms[i].Points[a], StringRandomizer.Instance.GetRandomString(10));

                if(MainData.Rooms[i].Walls.Count == MainData.Rooms[i].Points.Count - 1)
                {
                    _layoutWall.AssignEndPoint(MainData.Rooms[i].Points[0]);
                }
                else
                {
                    _layoutWall.AssignEndPoint(MainData.Rooms[i].Points[a + 1]);
                }
                MainData.Rooms[i].Walls.Add(_layoutWall);

            }
        }
    }
    #endregion


    #region ----- Cursor Controlling -----

    public void DrawNewRoomButtonEvent()
    {
        if(newRoom == null)
        {
            // Creating new room GameObject with 0 points, and assigning to the "newRoom" variable.
            GameObject _newRoom = Instantiate(RoomPrefab);
            _newRoom.transform.SetParent(RoomsWrapper);
            _newRoom.transform.localScale = new Vector3(1, 1, 1);
            newRoom = _newRoom;
            newRoom.GetComponent<LD_Room>().StartDrawRoom();

            // Creating StaticPoint Helper to the cursor
            GameObject _pointHelper = Instantiate(StaticPointPrefab);
            _pointHelper.transform.SetParent(tempUIWrapper);
            _pointHelper.transform.localScale = new Vector3(1, 1, 1);
            activePoint = _pointHelper;

        }
    }
    public void ClearNewRoom()
    {
        if(newRoom != null)
        {
            newRoom = null;
        }
        if(activePoint != null)
        {
            activePoint = null;
        }
        Destroy(tempUIWrapper.transform.GetChild(0).gameObject);
    }
    void CreateStaticPointHelperToCursor(GameObject _point)
    {
        Vector3 mousePosition, targetPosition;
        mousePosition = Input.mousePosition;

        //Convert the mousePosition according to World position
        targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(Mathf.FloorToInt(mousePosition.x), Mathf.FloorToInt(mousePosition.y), distance));

        if(useSnap)
        {
            targetPosition.x = Mathf.FloorToInt(targetPosition.x + .5f);
            targetPosition.y = Mathf.FloorToInt(targetPosition.y + .5f);
        }

        //Set the position of targetObject
        _point.transform.position = targetPosition;

    }
    #endregion

}
