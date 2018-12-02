using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {
    //实例
    public static GameManager Instance;
    //车厢长度
    public static float CarriageLength;

    public float Countdown = 60.0f;//倒计时
    //大人
    private int AdultNumber = 7;
    private string CurrentCharacter;
    public int CurrentID;
    public Adult[] Adults;
    public bool[] AdultDie;
    //劫匪A
    public Kidnapper Kidnappers;
    public bool KidnapperDie;
    //劫匪B
    public KidnapperBoss kidnapperboss;
    public bool bossdie;
    //狗
    public Dog dog;
    public bool DogDie=false;
    

    //鼠标位置
    public Vector3 MousePosition;
    private Vector3 mouseTargetPos;


    //结局
    public bool BadEnd = false;
    public bool NormalEnd = false;
    public bool TrueEnd = false;


	// Use this for initialization
	void Awake () {
        Instance = this;
        for(int i=0;i<Adults.Length;i++)
        {
            Adults[i].ID = i;
        }
	}
	
	// Update is called once per frame
	void Update () {


        //判断结局
        Countdown -= Time.deltaTime;//更新倒计时
        if(Countdown<=0)
        {
            if(KidnapperDie==false&&bossdie==false)//劫匪都没死
            {
                NormalEnd = true;   //NormalEnd场景会跳转到badend
            }
            else if(KidnapperDie==true&&bossdie==true)  //劫匪全死
            {
                TrueEnd = true;
            }
            else
            {
                BadEnd = true;
            }
        }
        
        
        //鼠标点击
        MousePosition = Input.mousePosition;
        if(Input.GetMouseButtonDown(0))//按下鼠标
        {
            //获取屏幕坐标
            Vector3 mouseScreenPos = Input.mousePosition;

            //定义射线
            Ray mouseRay = Camera.main.ScreenPointToRay(mouseScreenPos);
            RaycastHit mouseHit;
            
            //判断射线击中大人、狗或小孩
            if(Physics.Raycast(mouseRay,out mouseHit))
            {
                switch(mouseHit.collider.gameObject.tag)//
                {
                    case "Adult":
                        int ID = 0;
                        mouseHit.collider.gameObject.SendMessage("GetID");
                        break;
                    case "Dog":

                        break;
                    case "Children":
                        mouseHit.collider.gameObject.SendMessage("Cry");
                        break;
                    case "Carriage"://选中车厢则之前选中的人物移动到鼠标点击位置
                        MoveCharacter();
                        break;
                }

            }
            
        }
        

        //结局相关


	}
   

    //判断游戏结局
    public void GameOver()
    {

        if(TrueEnd)
        {
            SceneManager.LoadScene("TrueEnding");
            return;
        }
        if(NormalEnd)
        {
            SceneManager.LoadScene("NormalEnding");
            return;
        }
        if(BadEnd)
        {
            SceneManager.LoadScene("BadEnding");
            return;
        }
        //if(Countdown<=0)
        //{
        //    SceneManager.LoadScene("Ending");//游戏结束
        //}
    }


    //死亡
    public void Die(string tag="Adult",int ID=0)
    {
        if(tag=="Adult")    //大人死
        {
            AdultDie[ID] = true;
            Adults[ID].GetComponent <Adult> ().enabled = false;
            return;
        }
        if(tag=="Dog")  //  狗死
        {
            DogDie = true;
            dog.GetComponent < Dog> ().enabled = false;
            return;
        }
        if(tag=="KidnapperBoss")    //绑匪B死
        {
            bossdie = true;
            kidnapperboss.GetComponent<KidnapperBoss>().enabled = false;
        }
        else            //绑匪A死
        {
            KidnapperDie = true;
            Kidnappers.GetComponent < Kidnapper > ().enabled = false;
            return;
        }
    }


    //控制人物
    public void ControlCharacter(string tag,int ID=0)
    {
        CurrentCharacter = tag;
        if(tag=="Adult")
        {
            CurrentID = ID;
        }
    }

    //移动人物
    public void MoveCharacter()
    {
        MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);//ui坐标转世界坐标
        if(CurrentCharacter=="Adult")
        {
            Adults[CurrentID].Move(MousePosition.x);
        }
        else if(CurrentCharacter=="Dog")
        {
            dog.Move(MousePosition.x);
        }
    }



}
