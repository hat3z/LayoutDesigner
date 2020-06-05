using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LayoutGrid : MonoBehaviour
{
    public static LayoutGrid Instance;

    [SerializeField]
    private int rows;
    [SerializeField]
    private int cols;
    [SerializeField]
    private Vector2 gridSize;
    [SerializeField]
    private Vector2 gridOffset;


    public GameObject GridPoint;
    public Transform GridWrapper;
    private Vector2 cellSize;
    private Vector2 cellScale;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        GenerateGrid();
    }

    public void RefreshGrid()
    {
        for (int i = 0; i < GridWrapper.transform.childCount; i++)
        {
            Destroy(GridWrapper.GetChild(i).gameObject);
        }
        GenerateGrid();
    }

    public void GenerateGrid()
    {
        cellSize.x = 10;
        cellSize.y = 10;

        Vector2 newCellSize = new Vector2(gridSize.x / (float)cols, gridSize.y / (float)rows);

        cellScale.x = newCellSize.x / cellSize.x;
        cellScale.y = newCellSize.y / cellSize.y;

        cellSize = newCellSize;

        gridOffset.x = -(gridSize.x / 2) + cellSize.x / 2;
        gridOffset.y = -(gridSize.y / 2) + cellSize.y / 2;
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Vector2 pos = new Vector2(col * cellSize.x + gridOffset.x + transform.position.x, row * cellSize.y + gridOffset.y + transform.position.y);
                GameObject cO = Instantiate(GridPoint, pos, Quaternion.identity) as GameObject;
                cO.transform.SetParent(GridWrapper);
                cO.transform.localScale = new Vector3(1, 1, 1);

            }
        }

    }

}
