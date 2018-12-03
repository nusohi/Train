using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Children : MonoBehaviour
{
    public bool isCrying = false;
    public float CryTimer = 0;            //哭的冷却时间
    public float CryTime = 10f;

    public float StayTimer = 0;            //劫匪停留时间
    public float StayTime = 5f;

    void Update()
    {
        if (KidnapperMove._intance.navAgent.remainingDistance < 0.5f)
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
           
            KidnapperMove._intance.GameState = KidnapperMove.Patroling;
            StayTimer = 0;
        }
    }


    public void Cry()
    {
        if (isCrying) {
            return;
        }


        isCrying = true;

        print("哭的动画");

        // 哭的音效
        KidnapperMove._intance.navAgent.speed = 0;
        KidnapperMove._intance.GameState = KidnapperMove.GotoChild;
    }
}
