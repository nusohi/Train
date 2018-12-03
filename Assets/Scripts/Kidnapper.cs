using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kidnapper : MonoBehaviour
{
    public GameObject Gun;
    public float Attention = 0;//警戒值
    public GameObject DieKidnapper;
    public Animator animator;
    public Slider slider;
    private AudioSource audio;

    public float FireTimer = 0;
    public float FireTime = 3f;
    private int FireState = 0;

    public bool IsDead = false;

    
    
    void Start()
    {
        animator = this.GetComponent<Animator>();
        audio = this.GetComponent<AudioSource>();
    }
    
    void Update()
    {
        if (slider.value >= 1)
        {
            GameManager.Instance.BadEnd = true;
            //GameManager.Instance.GameOver();
        }

        if (FireState == 1)
        {
            FireTimer += Time.deltaTime;
        }

        if (FireTimer >= FireTime)
        {
            FireState = 0;
            Gun.SetActive(false);
            FireTimer = 0;
        }
         
    }

   public void AddAttention()
   {

       slider.value += 0.1f;
      
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
        Gun.SetActive(true);
        FireState = 1;
        audio.Play();
        slider.value += 0.5f;
    }
}
