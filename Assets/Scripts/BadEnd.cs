using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BadEnd : MonoBehaviour {

    public GameObject BadEndText;
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            BadEndText.SetActive(true);
        }

        LoadScene();
    }
    void LoadScene()
    {
        if (Input.GetMouseButtonDown(1))
        {
            SceneManager.LoadScene("Introduction");
        }
    }
}
