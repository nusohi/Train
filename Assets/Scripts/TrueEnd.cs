using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TrueEnd : MonoBehaviour {

    public string sceneName;

    public GameObject TrueEndText;
	// Use this for initialization
	void Start () {
        sceneName = SceneManager.GetActiveScene().name;
        print(sceneName);
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButtonDown(0))
        {
            TrueEndText.SetActive(true);
        }

        if (Input.GetMouseButtonDown(1))
        {
            SceneManager.LoadScene("Introduction");
        }
    }
}
