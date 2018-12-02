using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kidnapper : MonoBehaviour
{
    public int Attention = 0;



    public Adult Adult;
    public Children Child;
    public Kidnapper Kinnaper;



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
                if (Child.isCrying == true)
                {
                    //停在原地 待写


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
        IsDead = true;
        
        //死亡动画 待写

        GameManager.Instance.Die( "Kinnaper");
        // B警戒值增加  SendMessage("");

    }
}
