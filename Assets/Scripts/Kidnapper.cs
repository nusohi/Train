using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kidnapper : MonoBehaviour
{
    public int Attention = 0;//警戒值

   

    public Adult Adult;
    public Children Children;
    public Kidnapper kidnapper;



    public bool IsDead = false;

    public Rigidbody rigidbody;

    // Use this for initialization
    void Start()
    {
       
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Attention >= 100)
        {
            GameManager.Instance.GameOver();
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        switch (collider.tag)
        {
            case "Adult":
                /*  
                bool hasKnife = false;
                collider.SendMessage("HasKnife", hasKnife);
                */
                if (Adult.hasKnife == true)
                {
                    //击毙乘客 待写


                    Attention += 50;
                }
                else
                {
                    if (Adult.isMoving == true)
                    {
                        Attention += 20;
                    }
                    else
                    {
                        return;
                    }
                }


                break;
            case "Child":
            {
                if (Children.isCrying == true)
                {
                    


                    Attention += 10;
                }
                else
                {
                    return;
                }

                break;
            }
            case "Dog":
                break;
        }
    }

    public void Die()
    {
        print("劫匪我死了");
        IsDead = true;
        
        //死亡动画 待写

        GameManager.Instance.Die( "kidnapper");
        SendMessage("AddAttention");

    }
}
