﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KidnapperMove : MonoBehaviour
{
    public static KidnapperMove Instance;
    private Vector3 localScale;
    
    public Transform[] WayPoints;
    public float PatrolTimer = 0;
    public float PatrolTime = 3f;
    public NavMeshAgent navAgent;
    private int Index = 0;
	// Use this for initialization
    void Awake()
    {
        navAgent = this.GetComponent<NavMeshAgent>();
        navAgent.destination = WayPoints[Index].position;
    }
	void Start ()
	{
	    Instance = this;
	    localScale = transform.localScale;
    }
	
	// Update is called once per frame
	void Update () {
		Patrolling();
	}

    private void Patrolling()
    {
        if (navAgent.remainingDistance < 0.5f)
        {
            if (transform.position.x== WayPoints[3].position.x)
            {
                transform.localScale = new Vector3(-1*transform.localScale.x,transform.localScale.y,transform.localScale.z);
            }

            

            PatrolTimer += Time.deltaTime;
            if (PatrolTimer >= PatrolTime)
            {
                Index++;
                 Index %= 4;
                navAgent.destination = WayPoints[Index].position;
                PatrolTimer = 0;
               
            }
        }
    }
}
