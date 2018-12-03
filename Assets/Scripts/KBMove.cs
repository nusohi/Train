using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KBMove : MonoBehaviour {
    private Vector3 localScale;

    public Transform[] WayPoints;



    public float PatrolTimer = 0;
    public float PatrolTime = 3f;
    public NavMeshAgent navAgent;
    public Animator animator;

    private int Index = 0;




   



    

    // Use this for initialization
    void Awake()
    {
        navAgent = this.GetComponent<NavMeshAgent>();
        animator = this.GetComponent<Animator>();
        navAgent.destination = WayPoints[Index].position;
    }
    void Start()
    {
       
        localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
        { Patrolling(); }
       
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
                if (navAgent.destination.x < transform.position.x)
                {
                    //左转头
                    localScale.x = System.Math.Abs(localScale.x);
                    transform.localScale = localScale;

                }
                else
                {

                    {
                        localScale.x = -System.Math.Abs(localScale.x);
                        transform.localScale = localScale;
                    }

                }
                PatrolTimer = 0;

            }
        }
    }

   
}
