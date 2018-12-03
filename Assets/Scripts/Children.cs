using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Children : MonoBehaviour
{
    public bool isCrying = false;
    public float CryTimer = 0;
    public float CryTime = 10f;
    private Animator animator;

    void Start() {
        animator = this.GetComponent<Animator>();    
    }

    void Update()
    {
        if (isCrying == true)
            CryTimer += Time.deltaTime;
        if (CryTimer >= CryTime)
        {
            CryTimer = 0;
            isCrying = false;
            animator.SetTrigger("Idle");
            KidnapperMove._intance.GameState = KidnapperMove.Patroling;
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
    }
}
