using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridControl : MonoBehaviour
{
    public GridType _gridType;
    
    public Material fillMat, emptyMat, WallMat, TempMat, TrailMat;
    
    
    public GridControl[] Neighbors;


    public void ChangeColor()
    {
        if (_gridType == GridType.Empty) 
            GetComponent<Renderer>().material = emptyMat;
        if (_gridType == GridType.ColorFilled) 
            GetComponent<Renderer>().material = fillMat;
        if (_gridType == GridType.TempFill)
            GetComponent<Renderer>().material = TempMat;
        if (_gridType == GridType.Wall) 
            GetComponent<Renderer>().material = WallMat;
        if (_gridType == GridType.TrailFill) 
            GetComponent<Renderer>().material = TrailMat;
    }
    
    public void SetAsTrail() 
    {
        _gridType = GridType.TrailFill;
        ChangeColor();
    }
    
    public void FloodFill(int x, int y)
    {
        if (x >= 0 && x < 5 && y >= 0 && y < 9)
        {
                //girid map çağırılacak
                FloodFill(x + 1, y);
                FloodFill(x - 1, y);
                FloodFill(x, y + 1);
                FloodFill(x, y - 1);
            }
    }

    public enum GridType
    {
        Empty,
        ColorFilled,
        Wall,
        TempFill,
        TrailFill
    }
}


