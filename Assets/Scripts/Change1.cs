﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change1 : MonoBehaviour {
    public GameObject TextBlack;
    public float CountDown = 1f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    CountDown -= Time.deltaTime;
	    if (CountDown <= 0)
	    {
	        TextBlack.SetActive(true);
	        CountDown = 1f;
	    }
    }
}
