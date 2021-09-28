using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    [SerializeField] private Vector3 target;
    private Vector3 targetFirsPosition;
    private Vector3 startPosition;
    
    [Range(0,10)]
    [SerializeField] private float speed;
    
    private void Start()
    {
        startPosition = transform.position;
        targetFirsPosition = target;
    }

    void Update()
    {
        Move();
        GridControl();
    }

    void Move()
    {
        Vector3 dir = target - transform.position;
        transform.Translate(dir.normalized*speed*Time.deltaTime,Space.World );
        if (Vector3.Distance(transform.position, target) <= 0.4f)
        {
            target = (target == startPosition) ? target = targetFirsPosition : target = startPosition;
        }
    }

    void GridControl()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position,Vector3.down, out hit, 2))
        {
            GridControl element = hit.transform.GetComponent<GridControl>();
            if (element)
            {
                if (element._gridType == global::GridControl.GridType.ColorFilled)
                {
                    Destroy(gameObject);
                }
                else if (element._gridType == global::GridControl.GridType.TrailFill)
                {
                    if (FindObjectOfType<PlayerController>() && FindObjectOfType<PlayerController>().isAlive)
                    {
                        Debug.Log("Player çarptı enmy");
                        // LevelManager.instance.Die();  // En son yorum satırı kaldırılacak 
                    }
                       
                }
            }
        }
    }
}
