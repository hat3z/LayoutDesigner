using UnityEngine;

/// <summary>
/// author@htz
/// </summary>


public class LD_Controller : MonoBehaviour
{
    public static LD_Controller Instance;

    [Header("Wrappers")]
    public Transform LinesWrapper;
    public Transform PointsWrapper;

    [Header("Prefabs")]
    public GameObject RoomPrefab;

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

    }

    void DrawLayout()
    {
        for (int i = 0; i < MainData.Rooms.Count; i++)
        {
            CreateRoom(MainData.Rooms[i]);
        }
    }

    void CreateRoom(RoomData _roomData)
    {
        GameObject roomObject = Instantiate(RoomPrefab);
        roomObject.transform.SetParent(LinesWrapper, true);
        roomObject.transform.localScale = new Vector3(1, 1, 1);
        roomObject.GetComponent<LD_Room>().CreatePoints(_roomData.Points);
        AssignWalls();
    }

    void AssignWalls()
    {
        for (int i = 0; i < MainData.Rooms.Count; i++)
        {
            for (int a = 0; a < MainData.Rooms[i].Points.Count; a++)
            {
                LayoutWall _layoutWall = new LayoutWall("Wall" + (a + 1), MainData.Rooms[i].Points[a], MainData.Rooms[i].Points[a+1]);
                MainData.Rooms[i].Walls.Add(_layoutWall);
            }
        }
    }

}
