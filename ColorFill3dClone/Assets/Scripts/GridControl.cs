using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridControl : MonoBehaviour
{
    public GridType _gridType;
    
    public Material fillMat, emptyMat, WallMat, TempMat, TrailMat;
    
    
    public GridControl[] Neighbors;

    public static List<GridControl> Tail = new List<GridControl>();


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
    
    public void SetAsTrail() // Set as trail == iz olarak ayarla
    {
        _gridType = GridType.TrailFill;
        Tail.Add(this);
        ChangeColor();
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


