using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidnapperBoss : MonoBehaviour
{
    public int Attention = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if (Attention >= 0)
	    {
	        GameManager.Instance.GameOver();
        }
	}

    public void AddAttentionB()
    {
        Attention += 50;
    }
}
