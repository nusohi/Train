using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFadeInOut : MonoBehaviour {
    public static SceneFadeInOut Instance;
    public float fadeSpeed = 1.5f;
    public bool sceneStarting = true;
    private RawImage rawImage;
	// Use this for initialization
	void Awake () {
        rawImage = GetComponent<RawImage>();
        Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
        if (sceneStarting)
            StartScene();
	}
    private void FadeToClear()
    {
        rawImage.color = Color.Lerp(rawImage.color, Color.clear, fadeSpeed * Time.deltaTime);
    }
    private void FadeToBlack()
    {
        rawImage.color = Color.Lerp(rawImage.color, Color.black, fadeSpeed * Time.deltaTime);
    }
    void StartScene()
    {
        FadeToClear();
        if(rawImage.color.a<0.05f)  //当透明度足够则场景开始
        {
            rawImage.color = Color.clear;
            rawImage.enabled = false;
            sceneStarting = false;
        }
    }
    public void EndScene()
    {
        rawImage.enabled = true;
        FadeToBlack();
        //if(rawImage.color.a>0.95f)
        //{
        //    SceneManager.LoadScene("Introduction");
        //}
    }
}
