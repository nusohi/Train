using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    public bool InButton = false;
    public bool left = false;
    public float ScrollSpeed=1.0f;
    public float MaxLeftPos = -21f;
    public float MaxRightPos = 17f;


	
	void Update () {
		if(InButton)
        {
            MoveCamera(left);
        }
	}

    public void MoveCamera(bool left)
    {
        if (left) {
            if (transform.position.x <= MaxLeftPos)
                return;
            transform.position -= new Vector3(ScrollSpeed, 0, 0);
        }
        else {
            if (transform.position.x >= MaxRightPos)
                return;
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
