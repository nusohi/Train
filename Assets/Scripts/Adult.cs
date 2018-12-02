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
    public float speed = 15;

    public GameObject Knife;
    public GameObject Bone;
    public GameObject Arrow;
    private BoxCollider boxCollider;

    // 移动位置
    private Vector3 targetPosition;
    private Vector3 velocity;
    private float smoothTime = 0.1f;

    


    void Start() {
        targetPosition = transform.position;
        velocity = new Vector3(0, 0, 0);
        boxCollider = this.GetComponent<BoxCollider>();
    }

    void Update() {
        // 移动到目标位置
        if (isMoving) {
            transform.position = Vector3.SmoothDamp(this.transform.position, targetPosition, ref velocity, smoothTime);
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

    // 选择人物
    public void ClickOnMe() {
        // GameManager.Instance.ControlCharacter(this.tag, ID);
        Arrow.SetActive(true);
        print("ClickOnMe绑好了！！");
    }
    // 失去焦点
    public void UnClickOnMe() {
        Arrow.SetActive(false);
    }

    // 移动到位置
    public void Move(float X) {
        isMoving = true;
        velocity.x = Math.Abs(X - targetPosition.x) / speed;
        targetPosition.x = X;
    }

    //死亡
    public void Die() {
        GameManager.Instance.Die(this.tag, ID);
        boxCollider.enabled = false;
        /***************************************  缺动画  *************************************/
    }


    // 状态'接口'
    public void GetID(ref int ID) {
        ID = this.ID;
    }
    public void HasKnife(ref bool hasKnife) {
        hasKnife = this.hasKnife;
    }
    public void IsMoving(ref bool isMoving) {
        isMoving = this.isMoving;
    }
}
