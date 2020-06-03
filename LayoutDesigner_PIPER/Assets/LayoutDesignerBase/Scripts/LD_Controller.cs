using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// author@htz
/// </summary>


public class LD_Controller : MonoBehaviour
{

    public static LD_Controller Instance;

    //COMMONS
    public LineRenderer lineRenderer;

    [Space(10)]
    [SerializeField] private List<Transform> basePoints = new List<Transform>();


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

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
            Vector3 basePos = basePoints[i].position;
            basePointsArray[i] = new Vector3(basePos.x, basePos.y);
        }
        lineRenderer.SetPositions(basePointsArray);
    }

}
