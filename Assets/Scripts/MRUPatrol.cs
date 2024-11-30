using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MRUPatrol : MonoBehaviour
{
    [SerializeField] private Transform[] patrolPoints;
    [SerializeField] private float patrolTime;

    private int currentPoint = 0;
    private float patrolSpeed;

    void Start()
    {
        patrolSpeed = CalculateSpeed(patrolPoints[currentPoint].position, patrolPoints[(currentPoint + 1)].position, patrolTime);
    }
    void Update()
    {
        MoveToNextPoint();
    }
    private float CalculateSpeed(Vector3 startPoint, Vector3 endPoint, float time)
    {
        float distance = Vector3.Distance(startPoint, endPoint);
        float speed = distance / time;
        return speed;
    }
    void MoveToNextPoint()
    {
        if (Vector3.Distance(transform.position, patrolPoints[currentPoint].position) < 0.1f)
        {
            currentPoint = currentPoint + 1;
            if (2 <= currentPoint) 
            {
                currentPoint = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPoint].position, patrolSpeed * Time.deltaTime);
    }
}
