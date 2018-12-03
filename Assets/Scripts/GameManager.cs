using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {
    
    //实例
    public static GameManager Instance;
    //车厢长度
    public static float CarriageLength;
    //UI
    public float Countdown = 60.0f;//倒计时
    public Text CountDownText;


    //大人
    private int AdultNumber = 7;
    private string CurrentCharacter;
    public int CurrentID;
    public Adult[] Adults;
    public bool AdultDie=false;
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

    //小孩位置
    public Vector3 ChildPosition;

    //结局
    public bool BadEnd = false;
    public bool NormalEnd = false;
    public bool TrueEnd = false;


	// Use this for initialization
	void Start () {
        Instance = this;
        for(int i=0;i<Adults.Length;i++)
        {
            Adults[i].ID = i;
        }
        
    }
	
	// Update is called once per frame
	void Update () {

        //判断结局
        if(KidnapperDie&&bossdie)//劫匪全死
        {
            if(AdultDie||DogDie)//至少有一人或狗死亡
            {
                NormalEnd = true;
            }
            else//没人死亡
            {
                TrueEnd = true;
            }
        }
        else
        {
            if(Countdown>0)
            {
                //倒计时相关
                Countdown -= Time.deltaTime;//更新倒计时
                CountDownText.text = "Time  :  " + (int)Countdown;
            }
            else
            {
                if(KidnapperDie==false||bossdie==false)//劫匪没全死
                {
                    BadEnd = true;   //NormalEnd场景会跳转到badend
                }
            }

        }
        GameOver();
        
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
                        mouseHit.collider.gameObject.SendMessage("GetID");
                        break;
                    case "Dog":
                        mouseHit.collider.gameObject.SendMessage("GetID");
                        break;
                    case "Children":
                        // mouseHit.collider.gameObject.SendMessage("GetID");
                        ChildPosition = mouseHit.collider.gameObject.transform.position;
                        mouseHit.collider.gameObject.SendMessage("Cry");
                        
                        break;
                    case "Carriage"://选中车厢则之前选中的人物移动到鼠标点击位置
                        MoveCharacter();
                        break;
                    case "Wall":
                        print("不能走出车啊！");
                        break;
                    default:
                        print("碰到了别的东西 " + mouseHit.collider.gameObject.name);
                        MoveCharacter();
                        break;
                }

            }
            
        }
        

	}
   

    //游戏结局
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
            AdultDie = true;
            Adults[ID].GetComponent <Adult> ().enabled = false;
            return;
        }
        if(tag=="Dog")  //  狗死
        {
            DogDie = true;
            dog.GetComponent < Dog> ().enabled = false;
            return;
        }
        if (tag == "KidnapperBoss")    //绑匪B死
        {
            bossdie = true;
            kidnapperboss.GetComponent<KidnapperBoss>().enabled = false;
        }
        else if (tag == "Kidnapper")          //绑匪A死
        {
            KidnapperDie = true;
            Kidnappers.GetComponent<Kidnapper>().enabled = false;
            Kidnappers.GetComponent<KidnapperMove>().enabled = false;
            return;
        }
    }


    //控制人物
    public void ControlCharacter(string tag, int ID = 0) {
        CurrentCharacter = tag;
        if (tag == "Adult") {
            CurrentID = ID;
        }
        else if (tag == "Dog") {
            CurrentID = 0;
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
