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
    private string CurrentCharacter;
    private int CurrentID;
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

	// Use this for initialization
	void Awake () {
        Instance = this;
        for(int i=0;i<7;i++)
        {
            Adults[i].ID = i;
        }
	}
	
	// Update is called once per frame
	void Update () {

        Countdown -= Time.deltaTime;//更新倒计时
        if(Input.GetMouseButtonDown(0))//按下鼠标
        {
            MousePosition = Input.mousePosition;
        }
        
	}
   

    //判断游戏结局
    public void GameOver()
    {
        if(Countdown<=0)
        {
            SceneManager.LoadScene("Ending");//游戏结束
        }
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
        if(tag=="Dog")
        {
            DogDie = true;
            dog.GetComponent < Dog> ().enabled = false;
            return;
        }
        if(tag=="KidnapperBoss")
        {
            bossdie = true;
            kidnapperboss.GetComponent<KidnapperBoss>().enabled = false;
        }
        else
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
            Adults[ID].GetComponent < Adult > ().enabled = true;
            CurrentID = ID;
        }
        if(tag=="Dog")
        {
            dog.GetComponent<Dog>().enabled = true;
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
        else
        {
            dog.Move(MousePosition.x);
        }
    }



}
