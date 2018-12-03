using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Children : MonoBehaviour
{
    public bool isCrying = false;
    public float CryTimer = 0;
    public float CryTime = 15f;
    private Animator animator;

    public int CanStop = 0;

    public float StayTimer = 0;            //劫匪停留时间
    public float StayTime = 5f;

    void Start() {
        animator = this.GetComponent<Animator>();    
    }

    void Update()
    {
        if (KidnapperMove._intance.navAgent.remainingDistance < 0.5f&&CanStop==1)
        {
               StayTimer += Time.deltaTime;
        }
        if (isCrying == true)
        {
            CryTimer += Time.deltaTime;
            
        }

        if (CryTimer >= CryTime)
        {
            CryTimer = 0;
            isCrying = false;
           
        }

        if (StayTimer >= StayTime)
        {
           
            animator.SetTrigger("Idle");
            KidnapperMove._intance.GameState = KidnapperMove.Patroling;
            StayTimer = 0;
            CanStop = 0;
        }
    }


    public void Cry()
    {
        if (isCrying) {
            return;
        }


        isCrying = true;

        print("哭的动画");
        animator.SetTrigger("Cry");

        // 哭的音效
        KidnapperMove._intance.navAgent.speed = 0;
        KidnapperMove._intance.GameState = KidnapperMove.GotoChild;
        CanStop = 1;
    }
}
