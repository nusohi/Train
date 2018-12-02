using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adult : MonoBehaviour {

    public int ID { get; set; }
    public bool isMoving = false;
    public bool isDead = false;
    public bool hasKnife = false;
    public bool hasBone = false;
    public float step = 0.05f;

    public GameObject Knife;
    public GameObject Bone;
    private BoxCollider collision;

    // 移动位置
    private Vector3 targetPosition;
    private float LerpT = 1f;
    // 转头方向
    private Vector3 localScale;

    


    void Start() {
        targetPosition = transform.position;
        collision = this.GetComponent<BoxCollider>();
        localScale = transform.localScale;
    }

    void Update() {
        // 移动到目标位置
        if (isMoving) {
            LerpT = step / Math.Abs(targetPosition.x - transform.position.x);
            transform.position = Vector3.Lerp(this.transform.position, targetPosition, LerpT);
            /***************************************  缺动画  *************************************/
            if (transform.position == targetPosition)
                isMoving = false;
        }
    }
    
    // 碰撞检测
    private void OnTriggerEnter(Collider other) {
        switch (other.tag) {
            // 道具
            case "Knife":
                Destroy(other.gameObject);
                Knife.SetActive(true);
                hasKnife = true;
                break;
            case "Bone":
                Destroy(other.gameObject);
                Bone.SetActive(true);
                hasBone = true;
                break;
            // 碰到绑匪的眼神
            case "eyes":
                if (hasKnife) {
                    other.gameObject.SendMessage("Fire");
                    Die();
                }
                if (isMoving) {
                    other.gameObject.SendMessage("AddAttention");
                }
                break;
            // 活物
            case "Kidnapper":
                KillKindnapper(other.gameObject);
                break;
            case "Dog":
                EnableDog(other.gameObject);
                break;
            default:
                break;
        }
    }
    // 激活狗的操作
    private void EnableDog(GameObject gameObject) {
        if (hasBone) {
            gameObject.GetComponent<Dog>().enabled = true;
            hasBone = false;
        }
    }
    // 杀死劫匪
    private void KillKindnapper(GameObject gameObject) {
        if (hasKnife) {
            gameObject.SendMessage("Die");
            Knife.SetActive(false);
            hasKnife = false;
        }
    }
    

    // 移动到位置
    public void Move(float X) {
        // 转头
        if (X - targetPosition.x > 0)
            localScale.x = -Math.Abs(localScale.x);
        else
            localScale.x = Math.Abs(localScale.x);
        transform.localScale = localScale;

        // 移动
        isMoving = true;
        LerpT = step / Math.Abs(X - targetPosition.x);
        targetPosition.x = X;
    }

    //死亡
    public void Die() {
        GameManager.Instance.Die(this.tag, ID);

        /***************************************  缺动画  *************************************/
    }


    // 状态'接口'
    public void GetID() {
        print("获取ID" + ID);
        GameManager.Instance.ControlCharacter(this.tag, ID);
    }
    public void HasKnife(ref bool hasKnife) {
        hasKnife = this.hasKnife;
    }
    public void IsMoving(ref bool isMoving) {
        isMoving = this.isMoving;
    }
}
