using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform waypoint1;  
    public Transform waypoint2; 
    public float speed = 2f;    

    private Transform currentTarget; 

    void Start()
    {
        currentTarget = waypoint1;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, currentTarget.position) < 0.1f)
        {
            currentTarget = currentTarget == waypoint1 ? waypoint2 : waypoint1;
        }
    }
}
