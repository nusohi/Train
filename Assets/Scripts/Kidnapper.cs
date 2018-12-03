using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kidnapper : MonoBehaviour
{
    public int Attention = 0;//警戒值
    public GameObject DieKidnapper;
    public Animator animator;

    


    public bool IsDead = false;

    
    
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }
    
    void Update()
    {
        if (Attention >= 100)
        {
            GameManager.Instance.GameOver();
        }
    }

   

    public void Die()
    {
        print("劫匪我死了");
        IsDead = true;
        GameManager.Instance.Die("Kidnapper");
        SendMessage("AddAttentionB");
        Instantiate(DieKidnapper, new Vector3(this.transform.position.x,DieKidnapper.transform.position.y,this.transform.position.z), DieKidnapper.transform.rotation);
        Destroy(this.gameObject);
       
    }

    public void Fire() {
        print("Kidnapper开火动画！");
        animator.SetTrigger("Fire");
    }
}
