﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BansheeBoid : MonoBehaviour
{
    public Vector3 velocity = Vector3.zero;
    public Vector3 acceleration = Vector3.zero;
    public Vector3 force = Vector3.zero;

    public float mass = 1.0f;

    public float maxSpeed = 1000;
    public float maxForce = 10;

    public float speed = 0;

    public bool seekEnabled = false;
    public Vector3 target;
    public Transform targetTransform;

    public bool arriveEnabled = true;
    public float slowingDistance = 10;

    [Range(0.0f, 10.0f)]
    public float banking = 0.1f;

    public bool playerSteeringEnabled = false;
    public float playerForce = 100;

    public float damping = 0.1f;

    public bool pathFollowingEnabled = false;
    public float waypointDistance = 3;
    public Path path;

    public BigBoid pursueTarget;
    public bool pursueEnabled;
    public Vector3 pursueTargetPos;

    public GameObject banshee;

    public Vector3 Pursue(BigBoid pursueTarget)
    {
        pursueTarget = banshee.GetComponentInChildren<BigBoid>();
        float dist = Vector3.Distance(pursueTarget.transform.position, transform.position);
        float time = dist / maxSpeed;

        pursueTargetPos = pursueTarget.transform.position + pursueTarget.velocity * time;

        return Seek(pursueTargetPos);
    }



    public Vector3 FollowPath()
    {
        Vector3 nextWaypoint = path.NextWaypoint();

        if (!path.looped && path.IsLast())
        {
            return Arrive(nextWaypoint);
        }
        else
        {
            if (Vector3.Distance(transform.position, nextWaypoint) < waypointDistance)
            {
                path.AdvanceToNext();
            }
            return Seek(nextWaypoint);
        }
    }




    public Vector3 PlayerSteering()
    {
        Vector3 f = Vector3.zero;

        f += Input.GetAxis("Vertical") * transform.forward * playerForce;

        Vector3 projectedRight = transform.right;
        projectedRight.y = 0;
        projectedRight.Normalize();

        f += Input.GetAxis("Horizontal") * projectedRight * playerForce * 0.2f;


        return f;
    }


    // Start is called before the first frame update
    void Start()
    {

    }



    Vector3 Arrive(Vector3 target)
    {
        target = banshee.transform.position;
        Vector3 toTarget = target - transform.position;
        float dist = toTarget.magnitude;

        float ramped = (dist / slowingDistance) * maxSpeed;
        float clamped = Mathf.Min(ramped, maxSpeed);
        Vector3 desired = (toTarget / dist) * clamped;

        return desired - velocity;
    }

    Vector3 Seek(Vector3 target)
    {
        //target = banshee.transform.position;
        Vector3 toTarget = target - transform.position;
        Vector3 desired = toTarget.normalized * maxSpeed;

        return desired - velocity;
    }

    public Vector3 CalculateForce()
    {
        Vector3 force = Vector3.zero;
        if (seekEnabled)
        {
            force += Seek(target);
        }
        if (arriveEnabled)
        {
            force += Arrive(target);
        }
        if (playerSteeringEnabled)
        {
            force += PlayerSteering();
        }

        if (pathFollowingEnabled)
        {
            force += FollowPath();
        }

        if (pursueEnabled)
        {
            force += Pursue(pursueTarget);
        }

        return force;
    }

    // Update is called once per frame
    void Update()
    {
        
        force = CalculateForce();
        acceleration = force / mass;
        velocity += acceleration * Time.deltaTime;

        transform.position += velocity * Time.deltaTime;
        speed = velocity.magnitude;
        if (speed > 0)
        {
            Vector3 tempUp = Vector3.Lerp(transform.up, new Vector3(0, 0, 1) + (acceleration * banking), Time.deltaTime * 3.0f);
            transform.LookAt(transform.position + velocity, tempUp);
            //transform.forward = velocity;
            velocity -= (damping * velocity * Time.deltaTime);


        }
    }
}
