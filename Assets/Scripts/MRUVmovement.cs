using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MRUVmovement : MonoBehaviour
{
    [SerializeField] private Transform objective;
    [SerializeField] private float acceleration;

    [SerializeField] private float speed;

    private Vector3 direction;

    void Update()
    {
        direction = objective.position - transform.position;
        direction.Normalize();

        speed += acceleration * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, objective.position, speed * Time.deltaTime);
    }
}
