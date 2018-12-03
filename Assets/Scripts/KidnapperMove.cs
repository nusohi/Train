using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KidnapperMove : MonoBehaviour
{
   
    private Vector3 localScale;
    
    public Transform[] WayPoints;
    


    public float PatrolTimer = 0;
    public float PatrolTime = 3f;
    public NavMeshAgent navAgent;
    public Animator animator;
    
    private int Index = 0;
    



    public int GameState = Patroling;
    public static int Patroling = 0;
    public static int GotoChild = 1;
   
    

    public static KidnapperMove _intance;

    // Use this for initialization
    void Awake()
    {
        navAgent = this.GetComponent<NavMeshAgent>();
        animator = this.GetComponent<Animator>();
        navAgent.destination = WayPoints[Index].position;
    }
    void Start ()
	{
	    _intance = this;
	    localScale = transform.localScale;
    }
	
	// Update is called once per frame
	void Update () {
        if(GameState==Patroling)
        { Patrolling();}
        else
        {
    
           GotoChildren();
        }
	}

    private void Patrolling()
    {
        // 移动Move动画
        animator.SetTrigger("Move");

        navAgent.speed = 3.5f;
        if (navAgent.remainingDistance < 0.5f)
        {
           

            

            PatrolTimer += Time.deltaTime;
            if (PatrolTimer >= PatrolTime)
            {
                Index++;
                 Index %= 4;
                navAgent.destination = WayPoints[Index].position;
                if (navAgent.destination.x<transform.position.x)
            {
                //左转头
                localScale.x = Math.Abs(localScale.x);
                transform.localScale = localScale;

            }
            else
            {
               
                {
                    localScale.x = -Math.Abs(localScale.x);
                    transform.localScale = localScale;
                }
               
            }
                PatrolTimer = 0;
               
            }
        }
    }

    private void GotoChildren()
    {
        navAgent.speed = 20f;
       
        if (navAgent.destination.x < transform.position.x)
        {
            //左转头
            localScale.x = Math.Abs(localScale.x);
            transform.localScale = localScale;

        }
        else
        {

            {
                localScale.x = -Math.Abs(localScale.x);
                transform.localScale = localScale;
            }

        }
        
        navAgent.destination = new Vector3(GameManager.Instance.ChildPosition.x, GameManager.Instance.ChildPosition.y,this.transform.position.z);
       
      
    }
}
