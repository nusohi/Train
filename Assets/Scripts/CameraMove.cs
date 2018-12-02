using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    public bool InButton = false;
    public bool left = false;
    public float ScrollSpeed=1.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(InButton)
        {
            MoveCamera(left);
        }
	}

    public void MoveCamera(bool left)
    {
        if(left)
        {
            transform.position -= new Vector3(ScrollSpeed, 0, 0);
        }
        else
        {
            transform.position += new Vector3(ScrollSpeed, 0, 0);
        }
    }
    public void EnterButton(bool left)
    {
        InButton = true;
        this.left = left;
    }
    public void OutButton()
    {
        InButton = false;
    }
}
