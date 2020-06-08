using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class LD_Room : MonoBehaviour
{
    // privates
    Vector3 mousePosition, targetPosition;
    bool isDrawing = false;
    public LineRenderer lineRenderer;

    public UILineRenderer UILineRenderer;

    public GameObject StaticPoint;
    [Space(10)]
    [SerializeField] private List<GameObject> basePoints = new List<GameObject>();

    //RoomData
    RoomData myRoomData;

    //UI Elements
    public TMP_InputField RoomNameInput;

    // Start is called before the first frame update
    void Start()
    {
       // DrawBaseLayout();
        myRoomData = new RoomData(StringRandomizer.Instance.GetRandomString(10));
    }

    // Update is called once per frame
    void Update()
    {

        if (isDrawing)
        {
            if (basePoints.Count <= 3)
            {
                mousePosition = Input.mousePosition;

                targetPosition = Camera.main.ScreenToWorldPoint(
                    new Vector3(
                        mousePosition.x,
                        mousePosition.y,
                        10f));

                if (LayoutGrid.Instance.useSnap)
                {
                    targetPosition.x = Mathf.FloorToInt(targetPosition.x + LayoutGrid.Instance.cursorOffset);
                    targetPosition.y = Mathf.FloorToInt(targetPosition.y + LayoutGrid.Instance.cursorOffset);
                }

                StaticPoint.transform.position = targetPosition;
                Debug.Log("PlacedPos: " + targetPosition.x + "," + targetPosition.y);
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
                isDrawing = false;
                LD_Controller.Instance.ClearNewRoom();
                LD_Controller.Instance.MainData.AddRoomData(myRoomData);
                SetRoomNameInputPosition();
            }
        }

        //DrawBaseLayout();

        DrawBaseLayoutNew();

    }

    void DrawBaseLayoutNew()
    {

        Vector2[] basePointsArray = new Vector2[basePoints.Count];
        for (int i = 0; i < basePoints.Count; i++)
        {
            Vector2 basePos = basePoints[i].GetComponent<RectTransform>().transform.position;
            basePointsArray[i] = new Vector2(basePos.x, basePos.y);

        }
        UILineRenderer.Points = basePointsArray.ToArray();
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
        isDrawing = true;
    }

    public void SetRoomNameInputPosition()
    {
        Vector2 centerpos = GetComponent<RectTransform>().rect.center;
        RoomNameInput.gameObject.GetComponent<RectTransform>().transform.localPosition = GetComponent<RectTransform>().transform.localPosition;
        RoomNameInput.gameObject.SetActive(true);
    }

}
