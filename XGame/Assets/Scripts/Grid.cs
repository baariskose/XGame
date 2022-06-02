using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class Grid
{
    private Material material;
    private GameObject ColliderHolder;
    private int width;
    private int height;
    private float cellSize;
    private float cellRatio;
    private Vector3 orginPosition;
    private int[,] gridArray;
    private TextMesh[,] debugTextArray;
    float defaultCellSize=10;
    public Grid(int width, int height, float cellSize, Vector3 originPosition,Material material,GameObject ColliderHolde)
    {
        this.width = width;
        this.height = height;
        this.cellSize =cellSize;
        cellRatio = defaultCellSize /cellSize;
        this.orginPosition = originPosition;
        this.material = material;
        this.ColliderHolder = ColliderHolde;
 
        gridArray = new int[width, height];
        debugTextArray = new TextMesh[width, height];
        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                
                debugTextArray[x,y]= CreateText.CreateWorldText(gridArray[x, y].ToString(), ColliderHolde, null, GetWorldPosition(x, y) +new Vector3(cellSize,cellSize)*.5f, CalculateFontSize(60), Color.white, TextAnchor.MiddleCenter);
                debugTextArray[x, y].text = "";
                DrawLine(GetWorldPosition(x,y), GetWorldPosition(x,y+1),Color.green, 100f);
                DrawLine(GetWorldPosition(x, y), GetWorldPosition(x+1, y), Color.green, 100f);
            }
        }
      
        DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.green, 100f);
        DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.green, 100f);
    }
    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize + orginPosition;
    }
    private void GetXY(Vector3 worldPosition ,out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPosition-orginPosition).x / cellSize);
        y = Mathf.FloorToInt((worldPosition - orginPosition).y / cellSize);
    }
  
    public void SetValue(int x, int y, int value)
    {
        if(x>=0 && y >= 0 && x<width && y< height)
        {
            gridArray[x, y] = value;
            debugTextArray[x, y].text ="x";
        }
    }
    public void SetValue(Vector3 worldPosition, int value)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetValue(x, y, value);
    }
    public int GetValue(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return gridArray[x, y];
        }
        else
        {
            return 0;
        }
    }
    public int GetValue(Vector3 worldPosition)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        return GetValue(x, y);
    }
    void DrawLine(Vector3 start, Vector3 end, Color color, float duration = 0.2f)
    {
        GameObject myLine = new GameObject();
        myLine.tag = "line";
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        lr.material = material;
        lr.SetColors(color, color);
        lr.startWidth = 0.7f;
        lr.endWidth = 0.7f;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
       // GameObject.Destroy(myLine, duration);
    }
    public int CalculateFontSize(int fontSize)
    {
        if(cellRatio >= 3)
        {
            fontSize = 30;
        }
        return fontSize;
    }

}
