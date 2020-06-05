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


    // Start is called before the first frame update
    void Start()
    {
        DrawBaseLayout();
    }

    // Update is called once per frame
    void Update()
    {

        if(isDrawingNewRoom)
        {
            if(basePoints.Count <= 3)
            {
                mousePosition = Input.mousePosition;

                //Convert the mousePosition according to World position
                targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10f));

                //Set the position of targetObject

                StaticPoint.transform.position = targetPosition;
                //If Left Button is clicked
                if (Input.GetMouseButtonUp(0))
                {
                    //create the instance of targetObject and place it at given position.
                    GameObject staticPoint = Instantiate(StaticPoint);
                    staticPoint.transform.SetParent(LD_Controller.Instance.PointsWrapper);
                    staticPoint.transform.localScale = new Vector3(1, 1, 1);
                    basePoints.Add(staticPoint);
                }
            }
            else
            {
                isDrawingNewRoom = false;
                LD_Controller.Instance.ClearNewRoom();
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
        if(basePoints.Count != 3)
        {
            lineRenderer.loop = true;
        }
        else
        {
            lineRenderer.loop = false;
        }
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
