using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Children : MonoBehaviour
{
    public bool isCrying = false;
    public float CryTimer = 0;
    public float CryTime = 10f;

    void Update()
    {
        if(isCrying==true)
        CryTimer += Time.deltaTime;
        if (CryTimer >= CryTime)
        {
            CryTimer = 0;
            isCrying = false;
            KidnapperMove._intance.GameState = KidnapperMove.Patroling;
        }
    }


    public void Cry()
    {

        isCrying = true;
       // 哭的音效
        KidnapperMove._intance.navAgent.speed = 0;


        KidnapperMove._intance.GameState = KidnapperMove.GotoChild;
        
      

    }
}
