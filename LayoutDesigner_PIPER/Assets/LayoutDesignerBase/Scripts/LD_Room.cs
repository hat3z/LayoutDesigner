using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LD_Room : MonoBehaviour
{
    // privates
    bool isDrawingNewRoom = false;
    Vector3 mousePosition, targetPosition;

    public LineRenderer lineRenderer;
    public GameObject StaticPoint;
    [Space(10)]
    [SerializeField] private List<GameObject> basePoints = new List<GameObject>();

    //RoomData
    RoomData myRoomData;
    // Start is called before the first frame update
    void Start()
    {
        myRoomData = new RoomData(StringRandomizer.Instance.GetRandomString(10));
    }

    // Update is called once per frame
    void Update()
    {

        if(isDrawingNewRoom)
        {
            if(basePoints.Count <= 3)
            {
                mousePosition = Input.mousePosition;

                targetPosition = Camera.main.ScreenToWorldPoint(
                    new Vector3(
                        mousePosition.x, 
                        mousePosition.y, 
                        10f));

                if(LayoutGrid.Instance.useSnap)
                {
                    targetPosition.x = Mathf.FloorToInt(targetPosition.x + LayoutGrid.Instance.cursorOffset);
                    targetPosition.y = Mathf.FloorToInt(targetPosition.y + LayoutGrid.Instance.cursorOffset);
                }

                StaticPoint.transform.position = targetPosition;

                if (Input.GetMouseButtonUp(0))
                {
                    //create the instance of targetObject and place it at given position.
                    GameObject staticPoint = Instantiate(StaticPoint);
                    staticPoint.transform.SetParent(LD_Controller.Instance.PointsWrapper);
                    staticPoint.transform.localScale = new Vector3(1, 1, 1);
                    basePoints.Add(staticPoint);
                    myRoomData.Points.Add(new LayoutPoint(basePoints.Count + 1, 
                        staticPoint.GetComponent<RectTransform>().transform.localPosition.x, 
                        staticPoint.GetComponent<RectTransform>().transform.localPosition.y));
                }
            }
            else
            {
                isDrawingNewRoom = false;
                LD_Controller.Instance.ClearNewRoom();
                LD_Controller.Instance.MainData.AddRoomData(myRoomData);
            }
        }

        DrawBaseLayout();

    }


    void DrawBaseLayout()
    {
        lineRenderer.startWidth = .08f;
        lineRenderer.endWidth = .08f;
        lineRenderer.positionCount = basePoints.Count;
        Vector3[] basePointsArray = new Vector3[basePoints.Count];
        for (int i = 0; i < basePoints.Count; i++)
        {
            Vector3 basePos = basePoints[i].transform.position;
            basePointsArray[i] = new Vector3(basePos.x, basePos.y);
        }

        // Close lines.
        if(basePoints.Count != 3)
        {
            lineRenderer.loop = true;
        }
        else
        {
            lineRenderer.loop = false;
        }

        // Fill up the positions list.
        lineRenderer.SetPositions(basePointsArray);
    }

    public void CreatePoints(List<LayoutPoint> _layoutPoints)
    {
        for (int i = 0; i < _layoutPoints.Count; i++)
        {
            GameObject _layoutPointGo = Instantiate(StaticPoint);
            _layoutPointGo.transform.SetParent(LD_Controller.Instance.PointsWrapper, true);
            _layoutPointGo.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            _layoutPointGo.GetComponent<RectTransform>().transform.localPosition = new Vector3(_layoutPoints[i].x, _layoutPoints[i].y, 1);
            _layoutPoints[i].ID = i + 1;
            basePoints.Add(_layoutPointGo);
        }

    }

    public void StartDrawRoom()
    {
        isDrawingNewRoom = true;
    }


}
