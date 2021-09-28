using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class PlayerController : MonoBehaviour
{
    
    public bool isTrue = true;
    private bool isMooving;
    private Vector3 startPos, targetPos;
    [Range(0,10)]
    [SerializeField] float timeToMove = .1f;
    private bool moveActive = true;
    private Direction _direction;
    private Vector3 dir;
    private Vector3 dirA;
    public bool isAlive = true;

    private void Start()
    {
        _direction = Direction.NoDirection;
    }

    private void Update()
    {
        PlayerMove();
        GridControl();
    }

    void GridControl()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 2))
        {
            GridControl element = hit.transform.GetComponent<GridControl>();
            if (element)
            {
                Debug.Log("Grids Bulundu");
                if (element._gridType == global::GridControl.GridType.Empty)
                {
                    element.SetAsTrail();
                }
            }
            GetMoveTarget();
        }
        
        if (_direction!=Direction.NoDirection)
        {
            GridControl element;
            Debug.Log(dir);
            if (Physics.Raycast(transform.position, dir, out hit, 1f))
            {
                
                element = hit.transform.GetComponent<GridControl>();
                if (element)
                {
                    if (element._gridType == global::GridControl.GridType.Wall)
                    {
                        Debug.Log("Duvara Çarptı");
                        _direction = Direction.NoDirection;
                        isTrue = false;
                    }
                }
            }
        }
    }

    void GetMoveTarget()
    {
        dirA = dir + Vector3.down * .5f;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, dirA, out hit, 2))
        {
            GridControl element = hit.transform.GetComponent<GridControl>();
            if (element)
            {
                if (element._gridType == global::GridControl.GridType.TrailFill)
                {
                    Debug.Log("Level Manager çalışacak");
                    //LevelManager.instance.Die; // level manager aktif olunca aktif olucak
                }

                if (element._gridType == global::GridControl.GridType.Wall || element._gridType == global::GridControl.GridType.ColorFilled)
                {
                    if (Physics.Raycast(transform.position, Vector3.down, out hit, 2))
                    {
                        element = hit.transform.GetComponent<GridControl>();
                        if (element)
                        {
                            if (element._gridType == global::GridControl.GridType.TrailFill || element._gridType == global::GridControl.GridType.ColorFilled)
                            {
                                Debug.Log("alan hesabı olacak");
                                  //Kenarları aradaki alanı doldurma
                                LevelManager.instance.CheckFilledCellCount();
                            }
                        }
                    }
                }
            }
        }
    }
    void PlayerMove()
    {
        if (Input.GetKey(KeyCode.D) && !isMooving) { _direction = Direction.Right; }
        
        if (Input.GetKey(KeyCode.A) && !isMooving) { _direction = Direction.Left; }
        
        if (Input.GetKey(KeyCode.W) && !isMooving) { _direction = Direction.Up; }
        
        if (Input.GetKey(KeyCode.S) && !isMooving) { _direction = Direction.Down; }
        
        //Yönelmeler
        if (_direction == Direction.Right )
        {
            dir = Vector3.right;
            if (isTrue) StartCoroutine(MovePlayer(Vector3.right));
            isTrue = true;
        }
        
        if (_direction == Direction.Left )
        {
            dir = Vector3.left;
            if (isTrue) StartCoroutine(MovePlayer(Vector3.left));
            isTrue = true;
        }
        
        if (_direction == Direction.Up)
        {
            dir = new Vector3(0, 0, 1);
            if (isTrue) StartCoroutine(MovePlayer(Vector3.forward));
            isTrue = true;
        }
        
        if (_direction == Direction.Down)
        {
            dir = new Vector3(0, 0, -1);
            if (isTrue) StartCoroutine(MovePlayer(Vector3.back));
            isTrue = true;
        }
        
    }
   
    

    private  IEnumerator MovePlayer(Vector3 direction)
    {
        isMooving = true;
        float elapsedTime = 0;
        startPos = transform.position;
        targetPos = startPos + direction;
        while (elapsedTime < timeToMove )
        {
            transform.position = Vector3.Lerp(startPos,targetPos,(elapsedTime/timeToMove));
            elapsedTime += Time.deltaTime;
            isTrue = false;
            yield return null;
        }

        transform.position = targetPos;
        isMooving = false;
    }

    enum Direction
    {
        NoDirection,
        Up,
        Down,
        Right,
        Left
    }
   
}
