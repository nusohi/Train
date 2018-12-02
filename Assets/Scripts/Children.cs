using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Children : MonoBehaviour
{
    public bool isCrying = false;
    public float CryTimer = 0;
    public float CryTime = 3f;

    //public void OnTriggerEnter(Collider collider)
    //{
    //    if (collider.tag == "Kidnapper")
    //    {
    //        SendMessage("Cry");
    //    }
    //}
    public void Cry()
    {
        int k = Random.Range(0, 2);
        if (k == 0)       //哭
        {
            isCrying = true;
            KidnapperMove.Instance.navAgent.speed = 0;
            CryTimer += Time.deltaTime;
            if (CryTimer >= CryTime)
            {
                KidnapperMove.Instance.navAgent.speed = 3.5f;
                CryTimer = 0;
            }

        }
    }
}
