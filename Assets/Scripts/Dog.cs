using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : Adult {

    private void OnTriggerEnter(Collider other) {
        // print("狗被碰了！");
        if (!isMoving)
            return;
        switch (other.tag) {
            case "Kidnapper":
                other.gameObject.SendMessage("Die");
                break;
            default:
                break;
        }
    }

    //public new void Move(float X)
    //{
    //    if (isDead)
    //        return;
    //    // 转头
    //    if (X - targetPosition.x > 0)
    //    {
    //        // 向右看
    //        ///localScale.x = -Math.Abs(localScale.x);
    //        transform.rotation = turnRight;
    //    }
    //    else if (X - targetPosition.x < 0)
    //    {
    //        // 向左看
    //        ///localScale.x = Math.Abs(localScale.x);
    //        transform.rotation = turnLeft;
    //    }

    //    // 移动
    //    //isMoving = true;
    //    LerpT = step / Math.Abs(X - targetPosition.x);
    //    targetPosition.x = X;
    //}
    
}
