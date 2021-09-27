using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenarator : MonoBehaviour
{
    [Range(0,100)] public int row = 13;
    [Range(0,100)] public int col = 32;
    
    [SerializeField] private GameObject gridPrefab;
    public int[,] fillArea;
    void Start()
    {
        fillArea = new int[row, col];
        for (int r = 0; r < row; r++)
        {
            for (int c = 0; c < col; c++)
            {
                GameObject grid= Instantiate(gridPrefab, new Vector3(r, -0.5f, c), Quaternion.Euler(90,0,0));
                grid.transform.parent = transform;
                fillArea[r,c] = 0  ;
            }
        }
    }
}
