using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class NormalEnd : MonoBehaviour {


    public GameObject NormalEndText;
    public GameObject ReallyText;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            NormalEndText.SetActive(true);
            ReallyText.SetActive(true);
        }
        if (Input.GetMouseButtonDown(1))
        {
            SceneManager.LoadScene("Introduction");
        }
    }
}
