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
    protected Vector3 targetPosition;
    protected float LerpT = 1f;
    // 转头方向
    private Vector3 localScale;
    protected Quaternion turnLeft = new Quaternion(0, 0, 0, 0);
    protected Quaternion turnRight = new Quaternion(0, 180, 0, 0);



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
        // print("人" + ID + "碰到了" + other.name);
        switch (other.tag) {
            // 道具
            case "Knife":
                if (!hasBone) {
                    Destroy(other.gameObject);
                    Knife.SetActive(true);
                    hasKnife = true;
                }
                break;
            case "Bone":
                if (!hasKnife) {
                    Destroy(other.gameObject);
                    Bone.SetActive(true);
                    hasBone = true;
                }
                break;
            // 碰到绑匪的眼神
            case "Eyes":
                if (hasKnife) {
                    other.SendMessage("Fire");
                    Die();
                }
                if (isMoving) {
                    other.SendMessage("AddAttention");
                }
                // print("ID " + ID + " HasKinfe: " + (hasKnife ? "true" : "false") + "HasBone: " + (hasBone ? "true" : "false")); ;
                break;
            // 活物
            case "Kidnapper":
                KillKindnapper(other);
                break;
            case "Dog":
                EnableDog(other.gameObject);
                print("人" + ID + "碰到狗了");
                break;
            default:
                break;
        }
    }
    // 激活狗的操作
    private void EnableDog(GameObject gameObject) {
        if (hasBone) {
            print("骨头给狗了");
            gameObject.GetComponent<Dog>().enabled = true;
            hasBone = false;
            Bone.SetActive(false);
        }
    }
    // 杀死劫匪
    private void KillKindnapper(Collider collider) {
        if (hasKnife) {
            print("已经告诉Kidnapper他死了");
            collider.SendMessage("Die");
            Knife.SetActive(false);
            hasKnife = false;
        }
    }
    

    // 移动到位置
    public void Move(float X) {
        if (isDead)
            return;
        // 转头
        if (X - targetPosition.x > 0) {
            // 向右看
            ///localScale.x = -Math.Abs(localScale.x);
            transform.rotation = turnRight;
        }
        else if (X - targetPosition.x < 0){
            // 向左看
            ///localScale.x = Math.Abs(localScale.x);
            transform.rotation = turnLeft;
        }

        // 移动
        isMoving = true;
        LerpT = step / Math.Abs(X - targetPosition.x);
        targetPosition.x = X;
    }

    //死亡
    public void Die() {
        isDead = true;
        print("我死了，ID " + ID);
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
