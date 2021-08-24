using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour {

	public Camera[] cams;

	public void Start()
	{

	}

	public void camMainMenu ()
	{
		cams[0].enabled = true;
		cams[1].enabled = false;
		//cams[2].enabled = false;
	}

	public void camGameStart()
	{
		cams[0].enabled = false;
		cams[1].enabled = true;
		//cams[2].enabled = false;
	}
}
