using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LD_Line : MonoBehaviour
{

    public LineRenderer lineRenderer;

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
        lineRenderer.SetPositions(basePointsArray);
    }
}
